namespace lab2
{
    /// <summary>
    /// Генератор ключевой последовательности на основе LFSR (m = 26).
    /// Характеристический многочлен: P(x) = x²⁶ + x⁸ + x⁷ + x + 1.
    /// Нумерация разрядов: b₁ — младший (LSB), b₂₆ — старший (MSB).
    /// new_bit = b₈ ⊕ b₇ ⊕ b₁; на выход ключа подаётся b₂₆ до сдвига.
    /// </summary>
    public sealed class LFSRGenerator
    {
        private const uint Mask26 = 0x03FFFFFFU;

        private uint _state;

        /// <param name="initialState26">26 младших бит — начальное состояние (b₂₆ — старший бит uint).</param>
        public LFSRGenerator(uint initialState26)
        {
            _state = initialState26 & Mask26;
        }

        /// <summary>Возвращает следующий бит ключевого потока (0 или 1).</summary>
        public int NextBit()
        {
            uint keyBit = (_state >> 25) & 1;
            uint newBit = (_state >> 25) & 1 ^ ((_state >> 7) & 1) ^ ((_state >> 6) & 1) ^ (_state & 1);
            _state = ((_state << 1) | newBit) & Mask26;
            return (int)keyBit;
        }

        /// <summary>Текущее состояние регистра (для отладки).</summary>
        public uint State => _state & Mask26;
    }
}
