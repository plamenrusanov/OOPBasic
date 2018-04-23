public class Rectangle
{
    private string name;
    private double width;
    private double height;
    private double top;
    private double left;
    private double bottom;
    private double rigth;

    public Rectangle(string name, double width, double height, double top, double left)
    {
        this.name = name;
        this.width = width;
        this.height = height;
        this.top = top;
        this.left = left;
        this.bottom = top + height;
        this.rigth = left + width;
    }
    public Rectangle()
    {

    }
    public string Name
    {
        get { return name; }
        set { name = value; }
    }
    
    public void IntersectRectangles(Rectangle firstRect, Rectangle secondRect)
    {
        if ((firstRect.rigth < secondRect.left) || (secondRect.rigth < firstRect.left) || (firstRect.bottom < secondRect.top) || (secondRect.bottom < firstRect.top))
        {
            System.Console.WriteLine("false");
        }
        else
        {
            System.Console.WriteLine("true");
        }
       
    }
    /*
     * 
        int[] nM = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
        int numberOfRectangles = nM[0];
        int numberOfChecks = nM[1];

        List<Rectangle> data = new List<Rectangle>();
        for (int i = 0; i < numberOfRectangles; i++)
        {
            string[] rectArgs = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
            string name = rectArgs[0];
            double width = double.Parse(rectArgs[1]);
            double height = double.Parse(rectArgs[2]);
            double top = double.Parse(rectArgs[3]);
            double left = double.Parse(rectArgs[4]);
            Rectangle rectangle = new Rectangle(name, width, height, top, left);
            data.Add(rectangle);

        }

        for (int i = 0; i < numberOfChecks; i++)
        {
            string[] comparierNames = Console.ReadLine()
                .Split(new char[] { ' ' },StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            string first = comparierNames[0];
            string second = comparierNames[1];
            var firstRect = data.FirstOrDefault(r => r.Name == first);
            var secondRect = data.FirstOrDefault(r => r.Name == second);
            Rectangle rectangle = new Rectangle();
            rectangle.IntersectRectangles(firstRect, secondRect);

        }
        */
}