using System;

public class Reference
{
    private Scripture _scripture; // Scripture object associated with reference.
    public Reference(Scripture scripture) { // Constructor initializes the reference with a Scripture object.
        _scripture = scripture;
    }
    public string Display() { // Method to display the scripture.
        return _scripture.Display();
    }
    public static Scripture GetScriptureRef(string reference) { // Static method to get a Scripture object based on the provided reference.
        switch (reference)  { // Checks the reference string.
            case "John 3:16":
                return new Scripture("For God so loved the world that he gave his one and only Son, that whoever believes in him shall not perish but have eternal life.", "John 3:16");
            case "Proverbs 3:5-6":
                return new Scripture("Trust in the Lord with all thine heart; and lean not unto thine own understanding. In all thy ways acknowledge him, and he shall direct thy paths.", "Proverbs 3:5-6");
            case "Matthew 11:28-30":
                return new Scripture("Come unto me, all ye that labor and are heavy laden, and I will give you rest. Take my yoke upon you, and learn of me; for I am meek and lowly in heart: and ye shall find rest unto your souls. For my yoke is easy, and my burden is light.", "Matthew 11:28-30");
            case "2 Nephi 31:29":
                return new Scripture("And now, behold, my beloved brethren, this is the way; and there is none other way nor name given under heaven whereby man can be saved in the kingdom of God. And now, behold, this is the doctrine of Christ, and the only and true doctrine of the Father, and of the Son, and of the Holy Ghost, which is one God, without end. Amen.", "2 Nephi 31:29");
            case "Ephesians 2:8-9":
                return new Scripture("For by grace are ye saved through faith; and that not of yourselves: it is the gift of God: Not of works, lest any man should boast.", "Ephesians 2:8-9");
            default:
                return null; // Returns the corresponding Scripture object.
                // Returns null if the reference does not match.
        }
    }
}