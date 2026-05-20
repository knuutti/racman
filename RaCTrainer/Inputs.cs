using System;
using System.Collections.Generic;

namespace racman
{
    public static class Inputs
    {
        private static class ButtonSelector
        {
            private enum StandardBtns : uint
            {
                l2 = 0x1,
                r2 = 0x2,
                l1 = 0x4,
                r1 = 0x8,
                triangle = 0x10,
                circle = 0x20,
                cross = 0x40,
                square = 0x80,
                select = 0x100,
                l3 = 0x200,
                r3 = 0x400,
                start = 0x800,
                up = 0x1000,
                right = 0x2000,
                down = 0x4000,
                left = 0x8000,
            }

            private static Dictionary<StandardBtns, Buttons> standardToButtonsMapping = new Dictionary<StandardBtns, Buttons>
            {
                { StandardBtns.l2, Buttons.l2 },
                { StandardBtns.r2, Buttons.r2 },
                { StandardBtns.l1, Buttons.l1 },
                { StandardBtns.r1, Buttons.r1 },
                { StandardBtns.triangle, Buttons.triangle },
                { StandardBtns.circle, Buttons.circle },
                { StandardBtns.cross, Buttons.cross },
                { StandardBtns.square, Buttons.square },
                { StandardBtns.select, Buttons.select },
                { StandardBtns.l3, Buttons.l3 },
                { StandardBtns.r3, Buttons.r3 },
                { StandardBtns.start, Buttons.start },
                { StandardBtns.up, Buttons.up },
                { StandardBtns.right, Buttons.right },
                { StandardBtns.down, Buttons.down },
                { StandardBtns.left, Buttons.left },
            };

            private static Buttons ConvertToButtons(StandardBtns btn)
            {
                if (standardToButtonsMapping.TryGetValue(btn, out Buttons convertedBtn))
                {
                    return convertedBtn;
                }
                throw new ArgumentException("Conversion not found.");
            }

            /// <summary>
            /// Returns a list of buttons that are pressed.
            /// </summary>
            public static List<Buttons> GetButtons(uint mask)
            {
                var list = new List<Buttons>();

                foreach (StandardBtns button in Enum.GetValues(typeof(StandardBtns)))
                {
                    var buttonValue = (uint)button;

                    if (buttonValue != 0 && (mask & buttonValue) != 0)
                    {
                        list.Add(ConvertToButtons(button));
                    }
                }

                return list;
            }
        }

        public enum Buttons : uint
        {
            l2,
            r2,
            l1,
            r1,
            triangle,
            circle,
            cross,
            square,
            select,
            l3,
            r3,
            start,
            up,
            right,
            down,
            left,
        }

        public static float rx = 0.0f;
        public static float ry = 0.0f;
        public static float lx = 0.0f;
        public static float ly = 0.0f;

        public static int RawInputs;
        public static List<Buttons> Mask = new List<Buttons>();
        public static List<Buttons> DecodeMask(int mask)
        {
            return ButtonSelector.GetButtons((uint)mask);
        }
    }
}
