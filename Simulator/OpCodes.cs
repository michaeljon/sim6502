using System.Collections.Generic;

//
// See: https://github.com/eteran/pretendo/blob/master/doc/cpu/6502.txt
//
namespace InnoWerks.Simulators
{
    public static class OpCodes
    {
        public static readonly Dictionary<byte, OpCodeDefinition> OpCodeDefinitions = new()
        {
            { 0x00, new OpCodeDefinition("BRK", (cpu, addr) => cpu.BRK(addr), (cpu) => cpu.DecodeImplied(), 7) },
            { 0x01, new OpCodeDefinition("ORA", (cpu, addr) => cpu.ORA(addr), (cpu) => cpu.DecodeIndexedIndirect(), 6) },
            { 0x02, new OpCodeDefinition(null, (cpu, addr) => cpu.IllegalInstruction(addr), (cpu) => cpu.DecodeUndefined(), 0) },
            { 0x03, new OpCodeDefinition(null, (cpu, addr) => cpu.IllegalInstruction(addr), (cpu) => cpu.DecodeUndefined(), 0) },
            { 0x04, new OpCodeDefinition("TSB", (cpu, addr) => cpu.TSB(addr), (cpu) => cpu.DecodeZeroPage(), 5) },
            { 0x05, new OpCodeDefinition("ORA", (cpu, addr) => cpu.ORA(addr), (cpu) => cpu.DecodeZeroPage(), 3) },
            { 0x06, new OpCodeDefinition("ASL", (cpu, addr) => cpu.ASL(addr, false), (cpu) => cpu.DecodeZeroPage(), 5) },
            { 0x07, new OpCodeDefinition("RMB", (cpu, addr) => cpu.RMB(addr, 0), (cpu) => cpu.DecodeZeroPage(), 5) },
            { 0x08, new OpCodeDefinition("PHP", (cpu, addr) => cpu.PHP(addr), (cpu) => cpu.DecodeImplied(), 3) },
            { 0x09, new OpCodeDefinition("ORA", (cpu, addr) => cpu.ORA(addr), (cpu) => cpu.DecodeImmediate(), 2) },
            { 0x0a, new OpCodeDefinition("ASL", (cpu, addr) => cpu.ASL(addr, true), (cpu) => cpu.DecodeAccumulator(), 2) },
            { 0x0b, new OpCodeDefinition(null, (cpu, addr) => cpu.IllegalInstruction(addr), (cpu) => cpu.DecodeUndefined(), 0) },
            { 0x0c, new OpCodeDefinition("TSB", (cpu, addr) => cpu.TSB(addr), (cpu) => cpu.DecodeAbsolute(), 6) },
            { 0x0d, new OpCodeDefinition("ORA", (cpu, addr) => cpu.ORA(addr), (cpu) => cpu.DecodeAbsolute(), 4) },
            { 0x0e, new OpCodeDefinition("ASL", (cpu, addr) => cpu.ASL(addr, false), (cpu) => cpu.DecodeAbsolute(), 6) },
            { 0x0f, new OpCodeDefinition("BBR", (cpu, addr) => cpu.BBR(addr, 0), (cpu) => cpu.DecodeZeroPage(), 5) },

            { 0x10, new OpCodeDefinition("BPL", (cpu, addr) => cpu.BPL(addr), (cpu) => cpu.DecodeRelative(), 2) },
            { 0x11, new OpCodeDefinition("ORA", (cpu, addr) => cpu.ORA(addr), (cpu) => cpu.DecodeIndirectIndexed(), 5) },
            { 0x12, new OpCodeDefinition("ORA", (cpu, addr) => cpu.ORA(addr), (cpu) => cpu.DecodeIndirect(), 5) },
            { 0x13, new OpCodeDefinition(null, (cpu, addr) => cpu.IllegalInstruction(addr), (cpu) => cpu.DecodeUndefined(), 0) },
            { 0x14, new OpCodeDefinition("TRB", (cpu, addr) => cpu.TRB(addr), (cpu) => cpu.DecodeZeroPage(), 5) },
            { 0x15, new OpCodeDefinition("ORA", (cpu, addr) => cpu.ORA(addr), (cpu) => cpu.DecodeZeroPageIndexedX(), 4) },
            { 0x16, new OpCodeDefinition("ASL", (cpu, addr) => cpu.ASL(addr, false), (cpu) => cpu.DecodeZeroPageIndexedX(), 6) },
            { 0x17, new OpCodeDefinition("RMB", (cpu, addr) => cpu.RMB(addr, 1), (cpu) => cpu.DecodeZeroPage(), 5) },
            { 0x18, new OpCodeDefinition("CLC", (cpu, addr) => cpu.CLC(addr), (cpu) => cpu.DecodeImplied(), 2) },
            { 0x19, new OpCodeDefinition("ORA", (cpu, addr) => cpu.ORA(addr), (cpu) => cpu.DecodeAbsoluteIndexedY(), 4) },
            { 0x1a, new OpCodeDefinition("INC", (cpu, addr) => cpu.INC(addr), (cpu) => cpu.DecodeAccumulator(), 2) },
            { 0x1b, new OpCodeDefinition(null, (cpu, addr) => cpu.IllegalInstruction(addr), (cpu) => cpu.DecodeUndefined(), 0) },
            { 0x1c, new OpCodeDefinition("TRB", (cpu, addr) => cpu.TRB(addr), (cpu) => cpu.DecodeAbsolute(), 6) },
            { 0x1d, new OpCodeDefinition("ORA", (cpu, addr) => cpu.ORA(addr), (cpu) => cpu.DecodeAbsoluteIndexedX(), 4) },
            { 0x1e, new OpCodeDefinition("ASL", (cpu, addr) => cpu.ASL(addr, false), (cpu) => cpu.DecodeAbsoluteIndexedX(), 7) },
            { 0x1f, new OpCodeDefinition("BBR", (cpu, addr) => cpu.BBR(addr, 1), (cpu) => cpu.DecodeZeroPage(), 5) },

            { 0x20, new OpCodeDefinition("JSR", (cpu, addr) => cpu.JSR(addr), (cpu) => cpu.DecodeAbsolute(), 6) },
            { 0x21, new OpCodeDefinition("AND", (cpu, addr) => cpu.AND(addr), (cpu) => cpu.DecodeIndexedIndirect(), 6) },
            { 0x22, new OpCodeDefinition(null, (cpu, addr) => cpu.IllegalInstruction(addr), (cpu) => cpu.DecodeUndefined(), 0) },
            { 0x23, new OpCodeDefinition(null, (cpu, addr) => cpu.IllegalInstruction(addr), (cpu) => cpu.DecodeUndefined(), 0) },
            { 0x24, new OpCodeDefinition("BIT", (cpu, addr) => cpu.BIT(addr), (cpu) => cpu.DecodeZeroPage(), 3) },
            { 0x25, new OpCodeDefinition("AND", (cpu, addr) => cpu.AND(addr), (cpu) => cpu.DecodeZeroPage(), 3) },
            { 0x26, new OpCodeDefinition("ROL", (cpu, addr) => cpu.ROL(addr, false), (cpu) => cpu.DecodeZeroPage(), 5) },
            { 0x27, new OpCodeDefinition("RMB", (cpu, addr) => cpu.RMB(addr, 2), (cpu) => cpu.DecodeZeroPage(), 5) },
            { 0x28, new OpCodeDefinition("PLP", (cpu, addr) => cpu.PLP(addr), (cpu) => cpu.DecodeImplied(), 4) },
            { 0x29, new OpCodeDefinition("AND", (cpu, addr) => cpu.AND(addr), (cpu) => cpu.DecodeImmediate(), 2) },
            { 0x2a, new OpCodeDefinition("ROL", (cpu, addr) => cpu.ROL(addr, true), (cpu) => cpu.DecodeAccumulator(), 2) },
            { 0x2b, new OpCodeDefinition(null, (cpu, addr) => cpu.IllegalInstruction(addr), (cpu) => cpu.DecodeUndefined(), 0) },
            { 0x2c, new OpCodeDefinition("BIT", (cpu, addr) => cpu.BIT(addr), (cpu) => cpu.DecodeAbsolute(), 4) },
            { 0x2d, new OpCodeDefinition("AND", (cpu, addr) => cpu.AND(addr), (cpu) => cpu.DecodeAbsolute(), 4) },
            { 0x2e, new OpCodeDefinition("ROL", (cpu, addr) => cpu.ROL(addr, false), (cpu) => cpu.DecodeAbsolute(), 6) },
            { 0x2f, new OpCodeDefinition("BBR", (cpu, addr) => cpu.BBR(addr, 2), (cpu) => cpu.DecodeZeroPage(), 5) },

            { 0x30, new OpCodeDefinition("BMI", (cpu, addr) => cpu.BMI(addr), (cpu) => cpu.DecodeRelative(), 2) },
            { 0x31, new OpCodeDefinition("AND", (cpu, addr) => cpu.AND(addr), (cpu) => cpu.DecodeIndirectIndexed(), 5) },
            { 0x32, new OpCodeDefinition("AND", (cpu, addr) => cpu.AND(addr), (cpu) => cpu.DecodeIndirect(), 5) },
            { 0x33, new OpCodeDefinition(null, (cpu, addr) => cpu.IllegalInstruction(addr), (cpu) => cpu.DecodeUndefined(), 0) },
            { 0x34, new OpCodeDefinition("BIT", (cpu, addr) => cpu.BIT(addr), (cpu) => cpu.DecodeZeroPageIndexedX(), 4) },
            { 0x35, new OpCodeDefinition("AND", (cpu, addr) => cpu.AND(addr), (cpu) => cpu.DecodeZeroPageIndexedX(), 4) },
            { 0x36, new OpCodeDefinition("ROL", (cpu, addr) => cpu.ROL(addr, false), (cpu) => cpu.DecodeZeroPageIndexedX(), 6) },
            { 0x37, new OpCodeDefinition("RMB", (cpu, addr) => cpu.RMB(addr, 3), (cpu) => cpu.DecodeZeroPage(), 5) },
            { 0x38, new OpCodeDefinition("SEC", (cpu, addr) => cpu.SEC(addr), (cpu) => cpu.DecodeImplied(), 2) },
            { 0x39, new OpCodeDefinition("AND", (cpu, addr) => cpu.AND(addr), (cpu) => cpu.DecodeAbsoluteIndexedY(), 4) },
            { 0x3a, new OpCodeDefinition("DEC", (cpu, addr) => cpu.DEC(addr), (cpu) => cpu.DecodeAccumulator(), 2) },
            { 0x3b, new OpCodeDefinition(null, (cpu, addr) => cpu.IllegalInstruction(addr), (cpu) => cpu.DecodeUndefined(), 0) },
            { 0x3c, new OpCodeDefinition("BIT", (cpu, addr) => cpu.BIT(addr), (cpu) => cpu.DecodeAbsoluteIndexedX(), 4) },
            { 0x3d, new OpCodeDefinition("AND", (cpu, addr) => cpu.AND(addr), (cpu) => cpu.DecodeAbsoluteIndexedX(), 4) },
            { 0x3e, new OpCodeDefinition("ROL", (cpu, addr) => cpu.ROL(addr, false), (cpu) => cpu.DecodeAbsoluteIndexedX(), 7) },
            { 0x3f, new OpCodeDefinition("BBR", (cpu, addr) => cpu.BBR(addr, 3), (cpu) => cpu.DecodeZeroPage(), 5) },

            { 0x40, new OpCodeDefinition("RTI", (cpu, addr) => cpu.RTI(addr), (cpu) => cpu.DecodeImplied(), 6) },
            { 0x41, new OpCodeDefinition("EOR", (cpu, addr) => cpu.EOR(addr), (cpu) => cpu.DecodeIndexedIndirect(), 6) },
            { 0x42, new OpCodeDefinition(null, (cpu, addr) => cpu.IllegalInstruction(addr), (cpu) => cpu.DecodeUndefined(), 0) },
            { 0x43, new OpCodeDefinition(null, (cpu, addr) => cpu.IllegalInstruction(addr), (cpu) => cpu.DecodeUndefined(), 0) },
            { 0x44, new OpCodeDefinition(null, (cpu, addr) => cpu.IllegalInstruction(addr), (cpu) => cpu.DecodeUndefined(), 0) },
            { 0x45, new OpCodeDefinition("EOR", (cpu, addr) => cpu.EOR(addr), (cpu) => cpu.DecodeZeroPage(), 3) },
            { 0x46, new OpCodeDefinition("LSR", (cpu, addr) => cpu.LSR(addr, false), (cpu) => cpu.DecodeZeroPage(), 5) },
            { 0x47, new OpCodeDefinition("RMB", (cpu, addr) => cpu.RMB(addr, 4), (cpu) => cpu.DecodeZeroPage(), 5) },
            { 0x48, new OpCodeDefinition("PHA", (cpu, addr) => cpu.PHA(addr), (cpu) => cpu.DecodeImplied(), 3) },
            { 0x49, new OpCodeDefinition("EOR", (cpu, addr) => cpu.EOR(addr), (cpu) => cpu.DecodeImmediate(), 2) },
            { 0x4a, new OpCodeDefinition("LSR", (cpu, addr) => cpu.LSR(addr, true), (cpu) => cpu.DecodeAccumulator(), 2) },
            { 0x4b, new OpCodeDefinition(null, (cpu, addr) => cpu.IllegalInstruction(addr), (cpu) => cpu.DecodeUndefined(), 0) },
            { 0x4c, new OpCodeDefinition("JMP", (cpu, addr) => cpu.JMP(addr), (cpu) => cpu.DecodeAbsolute(), 3) },
            { 0x4d, new OpCodeDefinition("EOR", (cpu, addr) => cpu.EOR(addr), (cpu) => cpu.DecodeAbsolute(), 4) },
            { 0x4e, new OpCodeDefinition("LSR", (cpu, addr) => cpu.LSR(addr, false), (cpu) => cpu.DecodeAbsolute(), 6) },
            { 0x4f, new OpCodeDefinition("BBR", (cpu, addr) => cpu.BBR(addr, 4), (cpu) => cpu.DecodeZeroPage(), 5) },

            { 0x50, new OpCodeDefinition("BVC", (cpu, addr) => cpu.BVC(addr), (cpu) => cpu.DecodeRelative(), 2) },
            { 0x51, new OpCodeDefinition("EOR", (cpu, addr) => cpu.EOR(addr), (cpu) => cpu.DecodeIndirectIndexed(), 5) },
            { 0x52, new OpCodeDefinition("EOR", (cpu, addr) => cpu.EOR(addr), (cpu) => cpu.DecodeIndirect(), 5) },
            { 0x53, new OpCodeDefinition(null, (cpu, addr) => cpu.IllegalInstruction(addr), (cpu) => cpu.DecodeUndefined(), 0) },
            { 0x54, new OpCodeDefinition(null, (cpu, addr) => cpu.IllegalInstruction(addr), (cpu) => cpu.DecodeUndefined(), 0) },
            { 0x55, new OpCodeDefinition("EOR", (cpu, addr) => cpu.EOR(addr), (cpu) => cpu.DecodeZeroPageIndexedX(), 4) },
            { 0x56, new OpCodeDefinition("LSR", (cpu, addr) => cpu.LSR(addr, false), (cpu) => cpu.DecodeZeroPageIndexedX(), 6) },
            { 0x57, new OpCodeDefinition("RMB", (cpu, addr) => cpu.RMB(addr, 5), (cpu) => cpu.DecodeZeroPage(), 5) },
            { 0x58, new OpCodeDefinition("CLI", (cpu, addr) => cpu.CLI(addr), (cpu) => cpu.DecodeImplied(), 2) },
            { 0x59, new OpCodeDefinition("EOR", (cpu, addr) => cpu.EOR(addr), (cpu) => cpu.DecodeAbsoluteIndexedY(), 4) },
            { 0x5a, new OpCodeDefinition("PHY", (cpu, addr) => cpu.PHY(addr), (cpu) => cpu.DecodeImplied(), 3) },
            { 0x5b, new OpCodeDefinition(null, (cpu, addr) => cpu.IllegalInstruction(addr), (cpu) => cpu.DecodeUndefined(), 0) },
            { 0x5c, new OpCodeDefinition(null, (cpu, addr) => cpu.IllegalInstruction(addr), (cpu) => cpu.DecodeUndefined(), 0) },
            { 0x5d, new OpCodeDefinition("EOR", (cpu, addr) => cpu.EOR(addr), (cpu) => cpu.DecodeAbsoluteIndexedX(), 4) },
            { 0x5e, new OpCodeDefinition("LSR", (cpu, addr) => cpu.LSR(addr, false), (cpu) => cpu.DecodeAbsoluteIndexedX(), 7) },
            { 0x5f, new OpCodeDefinition("BBR", (cpu, addr) => cpu.BBR(addr, 5), (cpu) => cpu.DecodeZeroPage(), 5) },

            { 0x60, new OpCodeDefinition("RTS", (cpu, addr) => cpu.RTS(addr), (cpu) => cpu.DecodeImplied(), 6) },
            { 0x61, new OpCodeDefinition("ADC", (cpu, addr) => cpu.ADC(addr), (cpu) => cpu.DecodeIndexedIndirect(), 6) },
            { 0x62, new OpCodeDefinition(null, (cpu, addr) => cpu.IllegalInstruction(addr), (cpu) => cpu.DecodeUndefined(), 0) },
            { 0x63, new OpCodeDefinition(null, (cpu, addr) => cpu.IllegalInstruction(addr), (cpu) => cpu.DecodeUndefined(), 0) },
            { 0x64, new OpCodeDefinition("STZ", (cpu, addr) => cpu.STZ(addr), (cpu) => cpu.DecodeZeroPage(), 3) },
            { 0x65, new OpCodeDefinition("ADC", (cpu, addr) => cpu.ADC(addr), (cpu) => cpu.DecodeZeroPage(), 3) },
            { 0x66, new OpCodeDefinition("ROR", (cpu, addr) => cpu.ROR(addr, false), (cpu) => cpu.DecodeZeroPage(), 5) },
            { 0x67, new OpCodeDefinition("RMB", (cpu, addr) => cpu.RMB(addr, 6), (cpu) => cpu.DecodeZeroPage(), 5) },
            { 0x68, new OpCodeDefinition("PLA", (cpu, addr) => cpu.PLA(addr), (cpu) => cpu.DecodeImplied(), 4) },
            { 0x69, new OpCodeDefinition("ADC", (cpu, addr) => cpu.ADC(addr), (cpu) => cpu.DecodeImmediate(), 2) },
            { 0x6a, new OpCodeDefinition("ROR", (cpu, addr) => cpu.ROR(addr, true), (cpu) => cpu.DecodeAccumulator(), 2) },
            { 0x6b, new OpCodeDefinition(null, (cpu, addr) => cpu.IllegalInstruction(addr), (cpu) => cpu.DecodeUndefined(), 0) },
            { 0x6c, new OpCodeDefinition("JMP", (cpu, addr) => cpu.JMP(addr), (cpu) => cpu.DecodeAbsoluteIndirect(), 6) },
            { 0x6d, new OpCodeDefinition("ADC", (cpu, addr) => cpu.ADC(addr), (cpu) => cpu.DecodeAbsolute(), 4) },
            { 0x6e, new OpCodeDefinition("ROR", (cpu, addr) => cpu.ROR(addr, false), (cpu) => cpu.DecodeAbsolute(), 6) },
            { 0x6f, new OpCodeDefinition("BBR", (cpu, addr) => cpu.BBR(addr, 6), (cpu) => cpu.DecodeZeroPage(), 6) },

            { 0x70, new OpCodeDefinition("BVS", (cpu, addr) => cpu.BVS(addr), (cpu) => cpu.DecodeRelative(), 2) },
            { 0x71, new OpCodeDefinition("ADC", (cpu, addr) => cpu.ADC(addr), (cpu) => cpu.DecodeIndirectIndexed(), 5) },
            { 0x72, new OpCodeDefinition("ADC", (cpu, addr) => cpu.ADC(addr), (cpu) => cpu.DecodeIndirect(), 5) },
            { 0x73, new OpCodeDefinition(null, (cpu, addr) => cpu.IllegalInstruction(addr), (cpu) => cpu.DecodeUndefined(), 0) },
            { 0x74, new OpCodeDefinition("STZ", (cpu, addr) => cpu.STZ(addr), (cpu) => cpu.DecodeZeroPageIndexedX(), 4) },
            { 0x75, new OpCodeDefinition("ADC", (cpu, addr) => cpu.ADC(addr), (cpu) => cpu.DecodeZeroPageIndexedX(), 4) },
            { 0x76, new OpCodeDefinition("ROR", (cpu, addr) => cpu.ROR(addr, false), (cpu) => cpu.DecodeZeroPageIndexedX(), 6) },
            { 0x77, new OpCodeDefinition("RMB", (cpu, addr) => cpu.RMB(addr, 7), (cpu) => cpu.DecodeZeroPage(), 5) },
            { 0x78, new OpCodeDefinition("SEI", (cpu, addr) => cpu.SEI(addr), (cpu) => cpu.DecodeImplied(), 2) },
            { 0x79, new OpCodeDefinition("ADC", (cpu, addr) => cpu.ADC(addr), (cpu) => cpu.DecodeAbsoluteIndexedY(), 4) },
            { 0x7a, new OpCodeDefinition("PLY", (cpu, addr) => cpu.PLY(addr), (cpu) => cpu.DecodeImplied(), 4) },
            { 0x7b, new OpCodeDefinition(null, (cpu, addr) => cpu.IllegalInstruction(addr), (cpu) => cpu.DecodeUndefined(), 0) },
            { 0x7c, new OpCodeDefinition("JMP", (cpu, addr) => cpu.JMP(addr), (cpu) => cpu.DecodeIndexedAbsolute(), 6) },
            { 0x7d, new OpCodeDefinition("ADC", (cpu, addr) => cpu.ADC(addr), (cpu) => cpu.DecodeAbsoluteIndexedX(), 4) },
            { 0x7e, new OpCodeDefinition("ROR", (cpu, addr) => cpu.ROR(addr, false), (cpu) => cpu.DecodeAbsoluteIndexedX(), 7) },
            { 0x7f, new OpCodeDefinition("BBR", (cpu, addr) => cpu.BBR(addr, 7), (cpu) => cpu.DecodeZeroPage(), 5) },

            { 0x80, new OpCodeDefinition("BRA", (cpu, addr) => cpu.BRA(addr), (cpu) => cpu.DecodeRelative(), 3) },
            { 0x81, new OpCodeDefinition("STA", (cpu, addr) => cpu.STA(addr), (cpu) => cpu.DecodeIndexedIndirect(), 6) },
            { 0x82, new OpCodeDefinition(null, (cpu, addr) => cpu.IllegalInstruction(addr), (cpu) => cpu.DecodeUndefined(), 0) },
            { 0x83, new OpCodeDefinition(null, (cpu, addr) => cpu.IllegalInstruction(addr), (cpu) => cpu.DecodeUndefined(), 0) },
            { 0x84, new OpCodeDefinition("STY", (cpu, addr) => cpu.STY(addr), (cpu) => cpu.DecodeZeroPage(), 3) },
            { 0x85, new OpCodeDefinition("STA", (cpu, addr) => cpu.STA(addr), (cpu) => cpu.DecodeZeroPage(), 3) },
            { 0x86, new OpCodeDefinition("STX", (cpu, addr) => cpu.STX(addr), (cpu) => cpu.DecodeZeroPage(), 3) },
            { 0x87, new OpCodeDefinition("SMB", (cpu, addr) => cpu.SMB(addr, 0), (cpu) => cpu.DecodeZeroPage(), 5) },
            { 0x88, new OpCodeDefinition("DEY", (cpu, addr) => cpu.DEY(addr), (cpu) => cpu.DecodeImplied(), 2) },
            { 0x89, new OpCodeDefinition("BIT", (cpu, addr) => cpu.BIT(addr), (cpu) => cpu.DecodeImmediate(), 2) },
            { 0x8a, new OpCodeDefinition("TXA", (cpu, addr) => cpu.TXA(addr), (cpu) => cpu.DecodeImplied(), 2) },
            { 0x8b, new OpCodeDefinition(null, (cpu, addr) => cpu.IllegalInstruction(addr), (cpu) => cpu.DecodeUndefined(), 0) },
            { 0x8c, new OpCodeDefinition("STY", (cpu, addr) => cpu.STY(addr), (cpu) => cpu.DecodeAbsolute(), 4) },
            { 0x8d, new OpCodeDefinition("STA", (cpu, addr) => cpu.STA(addr), (cpu) => cpu.DecodeAbsolute(), 4) },
            { 0x8e, new OpCodeDefinition("STX", (cpu, addr) => cpu.STX(addr), (cpu) => cpu.DecodeAbsolute(), 4) },
            { 0x8f, new OpCodeDefinition("BBS", (cpu, addr) => cpu.BBS(addr, 0), (cpu) => cpu.DecodeZeroPage(), 5) },

            { 0x90, new OpCodeDefinition("BCC", (cpu, addr) => cpu.BCC(addr), (cpu) => cpu.DecodeRelative(), 2) },
            { 0x91, new OpCodeDefinition("STA", (cpu, addr) => cpu.STA(addr), (cpu) => cpu.DecodeIndirectIndexed(), 6) },
            { 0x92, new OpCodeDefinition("STA", (cpu, addr) => cpu.STA(addr), (cpu) => cpu.DecodeIndirect(), 5) },
            { 0x93, new OpCodeDefinition(null, (cpu, addr) => cpu.IllegalInstruction(addr), (cpu) => cpu.DecodeUndefined(), 0) },
            { 0x94, new OpCodeDefinition("STY", (cpu, addr) => cpu.STY(addr), (cpu) => cpu.DecodeZeroPageIndexedX(), 4) },
            { 0x95, new OpCodeDefinition("STA", (cpu, addr) => cpu.STA(addr), (cpu) => cpu.DecodeZeroPageIndexedX(), 4) },
            { 0x96, new OpCodeDefinition("STX", (cpu, addr) => cpu.STX(addr), (cpu) => cpu.DecodeZeroPageIndexedY(), 4) },
            { 0x97, new OpCodeDefinition("SMB", (cpu, addr) => cpu.SMB(addr, 1), (cpu) => cpu.DecodeZeroPage(), 5) },
            { 0x98, new OpCodeDefinition("TYA", (cpu, addr) => cpu.TYA(addr), (cpu) => cpu.DecodeImplied(), 2) },
            { 0x99, new OpCodeDefinition("STA", (cpu, addr) => cpu.STA(addr), (cpu) => cpu.DecodeAbsoluteIndexedY(), 5) },
            { 0x9a, new OpCodeDefinition("TXS", (cpu, addr) => cpu.TXS(addr), (cpu) => cpu.DecodeImplied(), 2) },
            { 0x9b, new OpCodeDefinition(null, (cpu, addr) => cpu.IllegalInstruction(addr), (cpu) => cpu.DecodeUndefined(), 0) },
            { 0x9c, new OpCodeDefinition("STZ", (cpu, addr) => cpu.STZ(addr), (cpu) => cpu.DecodeAbsolute(), 4) },
            { 0x9d, new OpCodeDefinition("STA", (cpu, addr) => cpu.STA(addr), (cpu) => cpu.DecodeAbsoluteIndexedX(), 5) },
            { 0x9e, new OpCodeDefinition("STZ", (cpu, addr) => cpu.STZ(addr), (cpu) => cpu.DecodeAbsoluteIndexedX(), 5) },
            { 0x9f, new OpCodeDefinition("BBS", (cpu, addr) => cpu.BBS(addr, 1), (cpu) => cpu.DecodeZeroPage(), 5) },

            { 0xa0, new OpCodeDefinition("LDY", (cpu, addr) => cpu.LDY(addr), (cpu) => cpu.DecodeImmediate(), 2) },
            { 0xa1, new OpCodeDefinition("LDA", (cpu, addr) => cpu.LDA(addr), (cpu) => cpu.DecodeIndexedIndirect(), 6) },
            { 0xa2, new OpCodeDefinition("LDX", (cpu, addr) => cpu.LDX(addr), (cpu) => cpu.DecodeImmediate(), 2) },
            { 0xa3, new OpCodeDefinition(null, (cpu, addr) => cpu.IllegalInstruction(addr), (cpu) => cpu.DecodeUndefined(), 0) },
            { 0xa4, new OpCodeDefinition("LDY", (cpu, addr) => cpu.LDY(addr), (cpu) => cpu.DecodeZeroPage(), 3) },
            { 0xa5, new OpCodeDefinition("LDA", (cpu, addr) => cpu.LDA(addr), (cpu) => cpu.DecodeZeroPage(), 3) },
            { 0xa6, new OpCodeDefinition("LDX", (cpu, addr) => cpu.LDX(addr), (cpu) => cpu.DecodeZeroPage(), 3) },
            { 0xa7, new OpCodeDefinition("SMB", (cpu, addr) => cpu.SMB(addr, 2), (cpu) => cpu.DecodeZeroPage(), 5) },
            { 0xa8, new OpCodeDefinition("TAY", (cpu, addr) => cpu.TAY(addr), (cpu) => cpu.DecodeImplied(), 2) },
            { 0xa9, new OpCodeDefinition("LDA", (cpu, addr) => cpu.LDA(addr), (cpu) => cpu.DecodeImmediate(), 2) },
            { 0xaa, new OpCodeDefinition("TAX", (cpu, addr) => cpu.TAX(addr), (cpu) => cpu.DecodeImplied(), 2) },
            { 0xab, new OpCodeDefinition(null, (cpu, addr) => cpu.IllegalInstruction(addr), (cpu) => cpu.DecodeUndefined(), 0) },
            { 0xac, new OpCodeDefinition("LDY", (cpu, addr) => cpu.LDY(addr), (cpu) => cpu.DecodeAbsolute(), 4) },
            { 0xad, new OpCodeDefinition("LDA", (cpu, addr) => cpu.LDA(addr), (cpu) => cpu.DecodeAbsolute(), 4) },
            { 0xae, new OpCodeDefinition("LDX", (cpu, addr) => cpu.LDX(addr), (cpu) => cpu.DecodeAbsolute(), 4) },
            { 0xaf, new OpCodeDefinition("BBS", (cpu, addr) => cpu.BBS(addr, 2), (cpu) => cpu.DecodeZeroPage(), 5) },

            { 0xb0, new OpCodeDefinition("BCS", (cpu, addr) => cpu.BCS(addr), (cpu) => cpu.DecodeRelative(), 2) },
            { 0xb1, new OpCodeDefinition("LDA", (cpu, addr) => cpu.LDA(addr), (cpu) => cpu.DecodeIndirectIndexed(), 5) },
            { 0xb2, new OpCodeDefinition("LDA", (cpu, addr) => cpu.LDA(addr), (cpu) => cpu.DecodeIndirect(), 5) },
            { 0xb3, new OpCodeDefinition(null, (cpu, addr) => cpu.IllegalInstruction(addr), (cpu) => cpu.DecodeUndefined(), 0) },
            { 0xb4, new OpCodeDefinition("LDY", (cpu, addr) => cpu.LDY(addr), (cpu) => cpu.DecodeZeroPageIndexedX(), 4) },
            { 0xb5, new OpCodeDefinition("LDA", (cpu, addr) => cpu.LDA(addr), (cpu) => cpu.DecodeZeroPageIndexedX(), 4) },
            { 0xb6, new OpCodeDefinition("LDX", (cpu, addr) => cpu.LDX(addr), (cpu) => cpu.DecodeZeroPageIndexedY(), 4) },
            { 0xb7, new OpCodeDefinition("SMB", (cpu, addr) => cpu.SMB(addr, 3), (cpu) => cpu.DecodeZeroPage(), 5) },
            { 0xb8, new OpCodeDefinition("CLV", (cpu, addr) => cpu.CLV(addr), (cpu) => cpu.DecodeImplied(), 2) },
            { 0xb9, new OpCodeDefinition("LDA", (cpu, addr) => cpu.LDA(addr), (cpu) => cpu.DecodeAbsoluteIndexedY(), 4) },
            { 0xba, new OpCodeDefinition("TSX", (cpu, addr) => cpu.TSX(addr), (cpu) => cpu.DecodeImplied(), 2) },
            { 0xbb, new OpCodeDefinition(null, (cpu, addr) => cpu.IllegalInstruction(addr), (cpu) => cpu.DecodeUndefined(), 0) },
            { 0xbc, new OpCodeDefinition("LDY", (cpu, addr) => cpu.LDY(addr), (cpu) => cpu.DecodeAbsoluteIndexedX(), 4) },
            { 0xbd, new OpCodeDefinition("LDA", (cpu, addr) => cpu.LDA(addr), (cpu) => cpu.DecodeAbsoluteIndexedX(), 4) },
            { 0xbe, new OpCodeDefinition("LDX", (cpu, addr) => cpu.LDX(addr), (cpu) => cpu.DecodeAbsoluteIndexedY(), 4) },
            { 0xbf, new OpCodeDefinition("BBS", (cpu, addr) => cpu.BBS(addr, 3), (cpu) => cpu.DecodeZeroPage(), 5) },

            { 0xc0, new OpCodeDefinition("CPY", (cpu, addr) => cpu.CPY(addr), (cpu) => cpu.DecodeImmediate(), 2) },
            { 0xc1, new OpCodeDefinition("CMP", (cpu, addr) => cpu.CMP(addr), (cpu) => cpu.DecodeIndexedIndirect(), 6) },
            { 0xc2, new OpCodeDefinition(null, (cpu, addr) => cpu.IllegalInstruction(addr), (cpu) => cpu.DecodeUndefined(), 0) },
            { 0xc3, new OpCodeDefinition(null, (cpu, addr) => cpu.IllegalInstruction(addr), (cpu) => cpu.DecodeUndefined(), 0) },
            { 0xc4, new OpCodeDefinition("CPY", (cpu, addr) => cpu.CPY(addr), (cpu) => cpu.DecodeZeroPage(), 3) },
            { 0xc5, new OpCodeDefinition("CMP", (cpu, addr) => cpu.CMP(addr), (cpu) => cpu.DecodeZeroPage(), 3) },
            { 0xc6, new OpCodeDefinition("DEC", (cpu, addr) => cpu.DEC(addr), (cpu) => cpu.DecodeZeroPage(), 5) },
            { 0xc7, new OpCodeDefinition("SMB", (cpu, addr) => cpu.SMB(addr, 4), (cpu) => cpu.DecodeZeroPage(), 5) },
            { 0xc8, new OpCodeDefinition("INY", (cpu, addr) => cpu.INY(addr), (cpu) => cpu.DecodeImplied(), 2) },
            { 0xc9, new OpCodeDefinition("CMP", (cpu, addr) => cpu.CMP(addr), (cpu) => cpu.DecodeImmediate(), 2) },
            { 0xca, new OpCodeDefinition("DEX", (cpu, addr) => cpu.DEX(addr), (cpu) => cpu.DecodeImplied(), 2) },
            { 0xcb, new OpCodeDefinition(null, (cpu, addr) => cpu.IllegalInstruction(addr), (cpu) => cpu.DecodeUndefined(), 0) },
            { 0xcc, new OpCodeDefinition("CPY", (cpu, addr) => cpu.CPY(addr), (cpu) => cpu.DecodeAbsolute(), 4) },
            { 0xcd, new OpCodeDefinition("CMP", (cpu, addr) => cpu.CMP(addr), (cpu) => cpu.DecodeAbsolute(), 4) },
            { 0xce, new OpCodeDefinition("DEC", (cpu, addr) => cpu.DEC(addr), (cpu) => cpu.DecodeAbsolute(), 6) },
            { 0xcf, new OpCodeDefinition("BBS", (cpu, addr) => cpu.BBS(addr, 4), (cpu) => cpu.DecodeZeroPage(), 5) },

            { 0xd0, new OpCodeDefinition("BNE", (cpu, addr) => cpu.BNE(addr), (cpu) => cpu.DecodeRelative(), 2) },
            { 0xd1, new OpCodeDefinition("CMP", (cpu, addr) => cpu.CMP(addr), (cpu) => cpu.DecodeIndirectIndexed(), 5) },
            { 0xd2, new OpCodeDefinition("CMP", (cpu, addr) => cpu.CMP(addr), (cpu) => cpu.DecodeIndirect(), 5) },
            { 0xd3, new OpCodeDefinition(null, (cpu, addr) => cpu.IllegalInstruction(addr), (cpu) => cpu.DecodeUndefined(), 0) },
            { 0xd4, new OpCodeDefinition(null, (cpu, addr) => cpu.IllegalInstruction(addr), (cpu) => cpu.DecodeUndefined(), 0) },
            { 0xd5, new OpCodeDefinition("CMP", (cpu, addr) => cpu.CMP(addr), (cpu) => cpu.DecodeZeroPageIndexedX(), 4) },
            { 0xd6, new OpCodeDefinition("DEC", (cpu, addr) => cpu.DEC(addr), (cpu) => cpu.DecodeZeroPageIndexedX(), 6) },
            { 0xd7, new OpCodeDefinition("SMB", (cpu, addr) => cpu.SMB(addr, 5), (cpu) => cpu.DecodeZeroPage(), 5) },
            { 0xd8, new OpCodeDefinition("CLD", (cpu, addr) => cpu.CLD(addr), (cpu) => cpu.DecodeImplied(), 2) },
            { 0xd9, new OpCodeDefinition("CMP", (cpu, addr) => cpu.CMP(addr), (cpu) => cpu.DecodeAbsoluteIndexedY(), 4) },
            { 0xda, new OpCodeDefinition("PHX", (cpu, addr) => cpu.PHX(addr), (cpu) => cpu.DecodeImplied(), 3) },
            { 0xdb, new OpCodeDefinition(null, (cpu, addr) => cpu.IllegalInstruction(addr), (cpu) => cpu.DecodeUndefined(), 0) },
            { 0xdc, new OpCodeDefinition(null, (cpu, addr) => cpu.IllegalInstruction(addr), (cpu) => cpu.DecodeUndefined(), 0) },
            { 0xdd, new OpCodeDefinition("CMP", (cpu, addr) => cpu.CMP(addr), (cpu) => cpu.DecodeAbsoluteIndexedX(), 4) },
            { 0xde, new OpCodeDefinition("DEC", (cpu, addr) => cpu.DEC(addr), (cpu) => cpu.DecodeAbsoluteIndexedX(), 7) },
            { 0xdf, new OpCodeDefinition("BBS", (cpu, addr) => cpu.BBS(addr, 5), (cpu) => cpu.DecodeZeroPage(), 5) },

            { 0xe0, new OpCodeDefinition("CPX", (cpu, addr) => cpu.CPX(addr), (cpu) => cpu.DecodeImmediate(), 2) },
            { 0xe1, new OpCodeDefinition("SBC", (cpu, addr) => cpu.SBC(addr), (cpu) => cpu.DecodeIndexedIndirect(), 6) },
            { 0xe2, new OpCodeDefinition(null, (cpu, addr) => cpu.IllegalInstruction(addr), (cpu) => cpu.DecodeUndefined(), 0) },
            { 0xe3, new OpCodeDefinition(null, (cpu, addr) => cpu.IllegalInstruction(addr), (cpu) => cpu.DecodeUndefined(), 0) },
            { 0xe4, new OpCodeDefinition("CPX", (cpu, addr) => cpu.CPX(addr), (cpu) => cpu.DecodeZeroPage(), 3) },
            { 0xe5, new OpCodeDefinition("SBC", (cpu, addr) => cpu.SBC(addr), (cpu) => cpu.DecodeZeroPage(), 3) },
            { 0xe6, new OpCodeDefinition("INC", (cpu, addr) => cpu.INC(addr), (cpu) => cpu.DecodeZeroPage(), 5) },
            { 0xe7, new OpCodeDefinition("SMB", (cpu, addr) => cpu.SMB(addr, 6), (cpu) => cpu.DecodeZeroPage(), 5) },
            { 0xe8, new OpCodeDefinition("INX", (cpu, addr) => cpu.INX(addr), (cpu) => cpu.DecodeImplied(), 2) },
            { 0xe9, new OpCodeDefinition("SBC", (cpu, addr) => cpu.SBC(addr), (cpu) => cpu.DecodeImmediate(), 2) },
            { 0xea, new OpCodeDefinition("NOP", (cpu, addr) => cpu.NOP(addr), (cpu) => cpu.DecodeImplied(), 2) },
            { 0xeb, new OpCodeDefinition(null, (cpu, addr) => cpu.IllegalInstruction(addr), (cpu) => cpu.DecodeUndefined(), 0) },
            { 0xec, new OpCodeDefinition("CPX", (cpu, addr) => cpu.CPX(addr), (cpu) => cpu.DecodeAbsolute(), 4) },
            { 0xed, new OpCodeDefinition("SBC", (cpu, addr) => cpu.SBC(addr), (cpu) => cpu.DecodeAbsolute(), 4) },
            { 0xee, new OpCodeDefinition("INC", (cpu, addr) => cpu.INC(addr), (cpu) => cpu.DecodeAbsolute(), 6) },
            { 0xef, new OpCodeDefinition("BBS", (cpu, addr) => cpu.BBS(addr, 6), (cpu) => cpu.DecodeZeroPage(), 5) },

            { 0xf0, new OpCodeDefinition("BEQ", (cpu, addr) => cpu.BEQ(addr), (cpu) => cpu.DecodeRelative(), 2) },
            { 0xf1, new OpCodeDefinition("SBC", (cpu, addr) => cpu.SBC(addr), (cpu) => cpu.DecodeIndirectIndexed(), 5) },
            { 0xf2, new OpCodeDefinition("SBC", (cpu, addr) => cpu.SBC(addr), (cpu) => cpu.DecodeIndirect(), 5) },
            { 0xf3, new OpCodeDefinition(null, (cpu, addr) => cpu.IllegalInstruction(addr), (cpu) => cpu.DecodeUndefined(), 0) },
            { 0xf4, new OpCodeDefinition(null, (cpu, addr) => cpu.IllegalInstruction(addr), (cpu) => cpu.DecodeUndefined(), 0) },
            { 0xf5, new OpCodeDefinition("SBC", (cpu, addr) => cpu.SBC(addr), (cpu) => cpu.DecodeZeroPageIndexedX(), 4) },
            { 0xf6, new OpCodeDefinition("INC", (cpu, addr) => cpu.INC(addr), (cpu) => cpu.DecodeZeroPageIndexedX(), 6) },
            { 0xf7, new OpCodeDefinition("SMB", (cpu, addr) => cpu.SMB(addr, 7), (cpu) => cpu.DecodeZeroPage(), 5) },
            { 0xf8, new OpCodeDefinition("SED", (cpu, addr) => cpu.SED(addr), (cpu) => cpu.DecodeImplied(), 2) },
            { 0xf9, new OpCodeDefinition("SBC", (cpu, addr) => cpu.SBC(addr), (cpu) => cpu.DecodeAbsoluteIndexedY(), 4) },
            { 0xfa, new OpCodeDefinition("PLX", (cpu, addr) => cpu.PLX(addr), (cpu) => cpu.DecodeImplied(), 4) },
            { 0xfb, new OpCodeDefinition(null, (cpu, addr) => cpu.IllegalInstruction(addr), (cpu) => cpu.DecodeUndefined(), 0) },
            { 0xfc, new OpCodeDefinition(null, (cpu, addr) => cpu.IllegalInstruction(addr), (cpu) => cpu.DecodeUndefined(), 0) },
            { 0xfd, new OpCodeDefinition("SBC", (cpu, addr) => cpu.SBC(addr), (cpu) => cpu.DecodeAbsoluteIndexedX(), 4) },
            { 0xfe, new OpCodeDefinition("INC", (cpu, addr) => cpu.INC(addr), (cpu) => cpu.DecodeAbsoluteIndexedX(), 7) },
            { 0xff, new OpCodeDefinition("BBS", (cpu, addr) => cpu.BBS(addr, 7), (cpu) => cpu.DecodeZeroPage(), 5) },
        };
    }
}