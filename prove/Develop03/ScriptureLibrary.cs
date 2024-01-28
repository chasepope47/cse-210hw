using System;
using System.Collections.Generic;
using System.Linq;

public class ScriptureLibrary
{
    private List<Scripture> scriptures;
    private Random random;

    public ScriptureLibrary()
    {
        scriptures = new List<Scripture>();
        random = new Random();

        // Add Bible Scriptures (King James Version)
        AddScripture("John 3:16", "For God so loved the world, that he gave his only begotten Son, that whosoever believeth in him should not perish, but have everlasting life.");
        AddScripture("Proverbs 3:5-6", "Trust in the LORD with all thine heart; and lean not unto thine own understanding. In all thy ways acknowledge him, and he shall direct thy paths.");

        // Add Book of Mormon Scriptures
        AddScripture("1 Nephi 3:7", "And it came to pass that I, Nephi, said unto my father: I will go and do the things which the Lord hath commanded, for I know that the Lord giveth no commandments unto the children of men, save he shall prepare a way for them that they may accomplish the thing which he commandeth.");
        AddScripture("Alma 36:3", "And now, O my son Helaman, behold, thou art in thy youth, and therefore, I beseech of thee that thou wilt hear my words and learn of me; for I do know that whosoever shall put their trust in God shall be supported in their trials, and their troubles, and their afflictions, and shall be lifted up at the last day.");
    }

    private void AddScripture(string reference, string text)
    {
        Reference scriptureReference = new Reference(reference);
        Scripture scripture = new Scripture(scriptureReference, text);
        scriptures.Add(scripture);
    }

    public Scripture GetRandomScripture()
    {
        int index = random.Next(scriptures.Count);
        return scriptures[index];
    }
}
