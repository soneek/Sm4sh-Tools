﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Security.Cryptography;
using Sm4shCommand.Classes;

namespace Sm4shCommand.Nodes
{
    public class CommandListGroup : BaseNode
    {
        private static ContextMenuStrip _menu;

        public CommandListGroup(Fighter fighter, uint CRC)
        {

            ContextMenuStrip = _menu;
            base.Fighter = fighter;
            base.CRC = CRC;
            Text = $"[{CRC:X8}]";

            for (int i = 0; i < 4; i++)
            {
                if (fighter[(ACMDType)i].EventLists.ContainsKey(CRC))
                    lists.Add(fighter[(ACMDType)i].EventLists[CRC]);
                else
                {
                    CommandList cml = new CommandList(CRC, fighter[(ACMDType)i]);
                    cml.Initialize();
                    lists.Add(cml);
                }
            }
        }
        public List<CommandList> lists = new List<CommandList>(4);
    }
}
