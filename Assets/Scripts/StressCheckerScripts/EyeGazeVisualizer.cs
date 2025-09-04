using UnityEngine;
using Unity.XR.PXR;
using UnityEngine.XR;
using System.Collections.Generic;
using TMPro;

public class EyeGazeVisualizer : MonoBehaviour
{
    [Header("Refs")]
    public GameObject gazeSphere;      // just for visualization, no scaling
    public Transform hmd;              // HMD camera transform
    public TextMeshPro pupilText;      // auto-created if null

    [Header("Raycast & Debug")]
    public float maxDistance = 50f;
    public LayerMask hittableLayers = ~0;
    public float followSmooth = 20f;

    [System.Serializable]
    public class ToggleBinding
    {
        public XRNode controller = XRNode.RightHand;
        public ToggleButton button = ToggleButton.Primary;
    }

    public enum ToggleButton { Primary, Secondary, TriggerButton, GripButton, StickPress }

    [Header("Toggle Settings")]
    public List<ToggleBinding> toggleBindings = new List<ToggleBinding>()
    {
        new ToggleBinding { controller = XRNode.LeftHand, button = ToggleButton.StickPress },
        new ToggleBinding { controller = XRNode.RightHand, button = ToggleButton.StickPress }
    };

    private readonly RaycastHit[] hits = new RaycastHit[8];
    private int ignoreMask;
    private bool visualEnabled = false;
    private Dictionary<ToggleBinding, bool> lastPressed = new Dictionary<ToggleBinding, bool>();

    private EyePupilInfo pupilInfo;

    void Awake()
    {
        if (hmd == null) hmd = Camera.main ? Camera.main.transform : null;

        if (gazeSphere)
        {
            var col = gazeSphere.GetComponent<Collider>();
            if (col) col.enabled = false;
            gazeSphere.transform.SetParent(null, true);
        }

        if (gazeSphere) ignoreMask |= 1 << gazeSphere.layer;
        int playerLayer = LayerMask.NameToLayer("Player");
        if (playerLayer >= 0) ignoreMask |= 1 << playerLayer;

        foreach (var b in toggleBindings)
            lastPressed[b] = false;

        // Auto-create text if none assigned
        if (pupilText == null && gazeSphere != null)
        {
            GameObject textObj = new GameObject("PupilText_TMP");
            textObj.transform.SetParent(gazeSphere.transform, false);
            textObj.transform.localPosition = new Vector3(0f, 0.15f, 0f);

            pupilText = textObj.AddComponent<TextMeshPro>();
            pupilText.fontSize = 10.0f; // made bigger
            pupilText.alignment = TextAlignmentOptions.Center;
            pupilText.color = Color.black;
            pupilText.enableWordWrapping = false;
            pupilText.text = "Pupil: -- / --";
        }

        // start hidden
        if (pupilText) pupilText.enabled = false;
        if (gazeSphere) gazeSphere.SetActive(false);
    }

    void Update()
    {
        // Toggle check
        foreach (var binding in toggleBindings)
        {
            var devices = new List<InputDevice>();
            InputDevices.GetDevicesAtXRNode(binding.controller, devices);

            if (devices.Count > 0 && devices[0].TryGetFeatureValue(GetUsage(binding.button), out bool pressed))
            {
                if (pressed && !lastPressed[binding])
                {
                    visualEnabled = !visualEnabled;

                    if (pupilText) pupilText.enabled = visualEnabled;
                    if (gazeSphere) gazeSphere.SetActive(visualEnabled); // toggle sphere with text
                }
                lastPressed[binding] = pressed;
            }
        }

        if (!visualEnabled || hmd == null || gazeSphere == null) return;

        if (!PXR_EyeTracking.GetCombineEyeGazeVector(out Vector3 gazeDir)) return;

        Vector3 origin = hmd.position;
        Vector3 dir = hmd.TransformDirection(gazeDir);

        int mask = hittableLayers & ~ignoreMask;
        int count = Physics.RaycastNonAlloc(origin, dir, hits, maxDistance, mask);

        RaycastHit? best = null;
        float bestDist = float.MaxValue;

        for (int i = 0; i < count; i++)
        {
            var tr = hits[i].transform;
            if (!tr || tr == gazeSphere.transform || tr.IsChildOf(hmd) || hmd.IsChildOf(tr))
                continue;

            if (hits[i].distance < bestDist)
            {
                best = hits[i];
                bestDist = hits[i].distance;
            }
        }

        if (best.HasValue)
        {
            Vector3 target = best.Value.point;
            gazeSphere.transform.position = Vector3.Lerp(
                gazeSphere.transform.position,
                target,
                1f - Mathf.Exp(-followSmooth * Time.deltaTime)
            );
        }

        UpdatePupilInfoAndUI();
    }

    private void UpdatePupilInfoAndUI()
    {
        unsafe
        {
            int res = PXR_MotionTracking.GetEyePupilInfo(ref pupilInfo);
            if (res == 0)
            {
                float leftMM = pupilInfo.leftEyePupilDiameter / 10f;
                float rightMM = pupilInfo.rightEyePupilDiameter / 10f;

                float leftX = pupilInfo.leftEyePupilPosition[0];
                float leftY = pupilInfo.leftEyePupilPosition[1];
                float rightX = pupilInfo.rightEyePupilPosition[0];
                float rightY = pupilInfo.rightEyePupilPosition[1];

                if (pupilText != null)
                {
                    pupilText.text =
                        $"L: {leftMM:F2} mm\nR: {rightMM:F2} mm\n" +
                        $"Lpos:({leftX:F2},{leftY:F2})\nRpos:({rightX:F2},{rightY:F2})";

                    if (hmd != null)
                        pupilText.rectTransform.rotation = Quaternion.LookRotation(pupilText.transform.position - hmd.position);
                }
            }
            else
            {
                if (pupilText != null) pupilText.text = "Pupil data unavailable";
            }
        }
    }

    private InputFeatureUsage<bool> GetUsage(ToggleButton tb)
    {
        return tb switch
        {
            ToggleButton.Primary => CommonUsages.primaryButton,
            ToggleButton.Secondary => CommonUsages.secondaryButton,
            ToggleButton.TriggerButton => CommonUsages.triggerButton,
            ToggleButton.GripButton => CommonUsages.gripButton,
            ToggleButton.StickPress => CommonUsages.primary2DAxisClick,
            _ => CommonUsages.primaryButton
        };
    }
}
