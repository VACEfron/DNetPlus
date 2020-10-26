using System;
using System.Linq;
using System.Text;

namespace Discord
{
    /// <summary>
    ///     A Unicode emoji.
    /// </summary>
    public class Emoji : IEmote
    {
        /// <summary>
        ///     Initializes a new <see cref="Emoji"/> class with the provided Unicode.
        /// </summary>
        /// <param name="unicode">The pure UTF-8 encoding of an emoji.</param>
        public Emoji(string unicode)
        {
            Name = unicode;
        }

        /// <inheritdoc />
        public string Name { get; }
        /// <summary>
        ///     Gets the Unicode representation of this emote.
        /// </summary>
        /// <returns>
        ///     A string that resolves to <see cref="Emoji.Name"/>.
        /// </returns>
        public override string ToString() => Name;

        /// <summary>
        ///     Determines whether the specified emoji is equal to the current one.
        /// </summary>
        /// <param name="other">The object to compare with the current object.</param>
        public override bool Equals(object other)
        {
            if (other == null) return false;
            if (other == this) return true;

            var otherEmoji = other as Emoji;
            if (otherEmoji == null) return false;

            return string.Equals(Name, otherEmoji.Name);
        }

        /// <inheritdoc />
        public override int GetHashCode() => Name.GetHashCode();

        /// <summary>
        /// Creates a DiscordEmoji from emote name that includes colons (eg. :thinking:). This method also supports skin tone variations (eg. :ok_hand::skin-tone-2:), standard emoticons (eg. :D), as well as guild emoji (still specified by :name:).
        /// </summary>
        /// <param name="client"><see cref="BaseDiscordClient"/> to attach to the object.</param>
        /// <param name="name">Name of the emote to find, including colons (eg. :thinking:).</param>
        /// <returns>Returns a <see cref="Emoji"/> object or null if the unicode is invalid.</returns>
        public static Emoji FromName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                return null;

            if (EmojiUtils.NameEmojis.ContainsKey(name))
                return new Emoji(name);

            return null;
        }

        /// <summary>
        /// Creates an emoji object from a unicode entity.
        /// </summary>
        /// <param name="unicode_entity">Unicode entity to create the object from.</param>
        /// <returns>Returns a <see cref="Emoji"/> object or null if the unicode is invalid.</returns>
        public static Emoji FromUnicode(string unicode)
        {
            if (string.IsNullOrWhiteSpace(unicode))
                return null;

            if (EmojiUtils.UnicodeEmojis == null)
                EmojiUtils.UnicodeEmojis = EmojiUtils.NameEmojis.GroupBy(e => e.Value, (key, xg) => xg.FirstOrDefault())
                .ToDictionary(xkvp => xkvp.Value, xkvp => xkvp.Key);

            if (EmojiUtils.UnicodeEmojis.ContainsKey(unicode))
                return new Emoji(EmojiUtils.UnicodeEmojis[unicode]);

            return null;
        }
    }
}
