using System.Collections.Generic;
using System.Diagnostics.Contracts;

namespace JamLib.Crypto
{
    public class GronsfeldCipher
    {
        string alphabet = " !\"#$%&'()*+,-./0123456789:<=>?@ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
        Dictionary<char, int> map;

        /// <summary>
        /// Uses the Default alphabet: " !"#$%&'()*+,-./0123456789:<=>?@ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz"
        /// </summary>
        public GronsfeldCipher() { this.map = GenerateAlphabetMapping(alphabet); }

        /// <summary>
        /// Uses a user specified alphabet
        /// </summary>
        public GronsfeldCipher(string alphabet)
        {
            this.alphabet = alphabet;
            this.map = GenerateAlphabetMapping(alphabet);
        }

        /// <summary>
        /// TODO: the way I deal with the custom alphabet is kinda hmm :(
        /// But this way I don't have to constantly lookup the char index in the custom alphabet
        /// </summary>
        private Dictionary<char, int> GenerateAlphabetMapping(string alphabet)
        {
            var map = new Dictionary<char, int>(alphabet.Length);
            for (int i = 0; i < alphabet.Length; i++)
            {
                map.Add(alphabet[i], i);
            }

            return map;
        }

        /// <summary>
        /// Encode a message
        /// Each element for the key represents a rotation value (binary number)
        /// The rotation value must be smaller then the alphabet length
        /// </summary>
        public char[] Encode(string msg, byte[] key) { return Transcode(msg, key, false); }

        /// <summary>
        /// Decode a message
        /// Each element for the key represents a rotation value (binary number)
        /// The rotation value must be smaller then the alphabet length
        /// </summary>
        public char[] Decode(string msg, byte[] key) { return Transcode(msg, key, true); }

        /// <summary>
        /// Takes care of the actuall de/encoding
        /// TODO: add char[] overloads for msg
        /// </summary>
        private char[] Transcode(string msg, byte[] key, bool decode)
        {
            Contract.Requires(msg != null && Contract.ForAll(msg, c => map.ContainsKey(c)));
            Contract.Requires(key != null && Contract.ForAll(key, k => k < alphabet.Length));

            char[] output = new char[msg.Length];

            for (int i = 0; i < msg.Length; i++)
            {
                output[i] = Shift(msg[i], key[i % key.Length], decode);
            }

            return output;
        }

        /// <summary>
        /// Shifts a passed element inside of the user supplied alphabet
        /// </summary>
        private char Shift(char c, int rot, bool reverse)
        {
            int index = map[c];
            int newIndex = reverse ? index - rot : index + rot;

            // Wrapping the new Index, a rot value >= alphabet lenght makes no sense, so we only wrap once instead of continously
            if (newIndex < 0) { newIndex += alphabet.Length; }
            else if (newIndex >= alphabet.Length) { newIndex -= alphabet.Length; }
            return alphabet[newIndex];
        }
    }
}
