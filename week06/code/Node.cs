public class Node
{
    public int Data { get; set; }
    public Node? Right { get; private set; }
    public Node? Left { get; private set; }

    public Node(int data)
    {
        this.Data = data;
    }

    public void Insert(int value)
    {
        // TODO Start Problem 1

        if (value < Data)
        {
            // Insert to the left
            if (Left is null)
                Left = new Node(value);
            else
                Left.Insert(value);//call
        }
        else if (value > Data)//only insert if value is greater than the current node
        {
            // Insert to the right
            if (Right is null)
                Right = new Node(value);
            else
                Right.Insert(value);
        }
    }

    public bool Contains(int value)
    {
        // the value matches the current node
        if (value==Data)
            return true;
        // the value is less than the current node
        if(value<Data)
        {
            if (Left is null)
                return false;
            return Left.Contains(value);
        }
        if (value>Data)
        {
            if (Right is null)
                return false;
            return Right.Contains(value);
        }
        return false;
    }

    public int GetHeight()
    {
        if (this==null)
        return 0; // Replace this line with the correct return statement(s)
        else
        {
            int leftHeight = 0;
            int rightHeight = 0;
            if (Left != null)
                leftHeight = Left.GetHeight();
            if (Right != null)
                rightHeight = Right.GetHeight();
            return 1 + Math.Max(leftHeight, rightHeight);
        }
    }
}