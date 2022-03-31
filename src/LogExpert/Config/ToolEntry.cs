using System;
using System.Windows.Forms;

namespace LogExpert
{
    [Serializable]
    public class ToolEntry
    {
        #region Fields

        public string args = "";
        public string cmd = "";
        public string columnizerName = "";
        public string iconFile;
        public int iconIndex;
        public bool isFavourite;
        public string name;
        public bool sysout = false;
        public string workingDir = "";
        // the keyboard shortcut's key used for this tool
        public int shortcutKey = 0;
        // the keyboard shortcut's modifiers used for this tool
        public enum theShortcutModifiers { CtrlModifier, ShiftModifier, AltModifier, WinModifier, NrOfModifiers };
        public bool[] shortcutModifiers = new bool[(int)theShortcutModifiers.NrOfModifiers] { false, false, false, false };

        #endregion

        #region Public methods

        public override string ToString()
        {
            return Util.IsNull(this.name) ? this.cmd : this.name;
        }

        // used for tooltips
        public string ToLongString()
        {
            return ToString() + ((shortcutKey != 0) ? (" (" + shortcutText() + ")") : "");
        }

        // create a short text for current keyboard shortcut, ex: "A + S" for Alt+S
        public string shortcutText()
        {
            int nKey = shortcutKey;
            Keys key = (Keys)nKey;
            bool ctrlModif = shortcutModifiers[(int)ToolEntry.theShortcutModifiers.CtrlModifier];
            bool shiftModif = shortcutModifiers[(int)ToolEntry.theShortcutModifiers.ShiftModifier];
            bool altModif = shortcutModifiers[(int)ToolEntry.theShortcutModifiers.AltModifier];
            bool winModif = shortcutModifiers[(int)ToolEntry.theShortcutModifiers.WinModifier];
            return (key != Keys.None) ? ((ctrlModif ? "C + " : "") + (shiftModif ? "S + " : "") + (altModif ? "A + " : "") + (winModif ? "W + " : "") + key.ToString()) : "";
        }

        public ToolEntry Clone()
        {
            ToolEntry clone = new ToolEntry();
            clone.cmd = this.cmd;
            clone.args = this.args;
            clone.name = this.name;
            clone.sysout = this.sysout;
            clone.columnizerName = this.columnizerName;
            clone.isFavourite = this.isFavourite;
            clone.iconFile = this.iconFile;
            clone.iconIndex = this.iconIndex;
            clone.workingDir = this.workingDir;
            clone.shortcutKey = this.shortcutKey;
            for (int i = 0; (this.shortcutModifiers != null) && (i < (int)theShortcutModifiers.NrOfModifiers); ++i) {
                clone.shortcutModifiers[i] = this.shortcutModifiers[i];
            }
            return clone;
        }

        #endregion
    }
}