using System;

public class TrainComposition
{

    public class Train
    {
        public Train(int Id)
        {
            this.Id = Id;
        }

        public Train Left { get; internal set; }
        public Train Right { get; internal set; }

        public int Id { get; private set; }
    }

    public Train MostLeft { get; set; }
    public Train MostRight { get; private set; }

    private Train initFirstTrain(int Id)
    {
        Train newTrain = new Train(Id);
        this.MostLeft = newTrain;
        this.MostRight = newTrain;
        return newTrain;
    }

    public void AttachWagonFromLeft(int wagonId)
    {

        Train previousMostLeft = this.MostLeft;
        if (previousMostLeft == null)
        {
            initFirstTrain(wagonId);
        } else
        {
            Train newOne = new Train(wagonId);
            previousMostLeft.Left = newOne;
            this.MostLeft = newOne;
        }

        
    }

    public void AttachWagonFromRight(int wagonId)
    {
        Train previousMostRight = this.MostRight;
        if (previousMostRight == null)
        {
            initFirstTrain(wagonId);
        }
        else
        {
            Train newOne = new Train(wagonId);
            previousMostRight.Right = newOne;
            this.MostRight = newOne;
        }
    }

    public int DetachWagonFromLeft()
    {
        Train previousMostLeft = this.MostLeft;
        if (previousMostLeft == null)
        {
            return -1;
        }
        else
        {
            if(previousMostLeft.Right!=null)
            {
                this.MostLeft = previousMostLeft.Right;
                previousMostLeft.Right.Left = null;
                return previousMostLeft.Id;
            } else
            {
                // the last one
                this.MostLeft = null;
                this.MostRight = null;
                return previousMostLeft.Id;
            }
        }
    }

    public int DetachWagonFromRight()
    {
        Train previousMostRight = this.MostRight;
        if (previousMostRight == null)
        {
            return -1;
        }
        else
        {
            if (previousMostRight.Left != null)
            {
                this.MostRight = previousMostRight.Left;
                previousMostRight.Left.Right = null;
                return previousMostRight.Id;
            }
            else
            {
                // the last one
                this.MostLeft = null;
                this.MostRight = null;
                return previousMostRight.Id;
            }
        }
    }

    public static void MainKak(string[] args)
    {
        TrainComposition tree = new TrainComposition();
        tree.AttachWagonFromLeft(7);
        tree.AttachWagonFromLeft(13);
        Console.WriteLine(tree.DetachWagonFromRight()); // 7 
        Console.WriteLine(tree.DetachWagonFromLeft()); // 13
        Console.ReadLine();
    }
}