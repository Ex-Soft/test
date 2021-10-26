using System;

namespace BridgeStd
{
    public interface IWallCreator
    {
        void BuildWallWithDoor();
        void BuildWall();
        void BuildWallWithWindow();
    }

    public interface IBuildingCompany
    {
        void BuildFoundation();
        void BuildRoom();
        void BuildRoof();
        IWallCreator WallCreator { get; set; }
    }

    public class BuildingCompany : IBuildingCompany
    {
        public void BuildFoundation()
        {
            Console.WriteLine("Foundation is built.{0}", Environment.NewLine);
        }
        
        public void BuildRoom()
        {
            WallCreator.BuildWallWithDoor();
            WallCreator.BuildWall();
            WallCreator.BuildWallWithWindow();
            WallCreator.BuildWall();
            Console.WriteLine("Room finished.{0}", Environment.NewLine);
        }
        
        public void BuildRoof()
        {
            Console.WriteLine("Roof is done.{0}", Environment.NewLine);
        }

        public IWallCreator WallCreator { get; set; }
    }

    public class BrickWallCreator : IWallCreator
    {
        public void BuildWallWithDoor()
        {}

        public void BuildWall()
        {}

        public void BuildWallWithWindow()
        {}
    }

    public class ConcreteSlabWallCreator : IWallCreator
    {
        public void BuildWallWithDoor()
        {}

        public void BuildWall()
        {}

        public void BuildWallWithWindow()
        {}
    }

    public class Runner
    {
        public static void Run()
        {
            var brickWallCreator = new BrickWallCreator();
            var concreteSlabWallCreator = new ConcreteSlabWallCreator();

            var buildingCompany = new BuildingCompany();

            buildingCompany.BuildFoundation();
            
            buildingCompany.WallCreator = concreteSlabWallCreator;
            buildingCompany.BuildRoom();

            buildingCompany.WallCreator = brickWallCreator;
            buildingCompany.BuildRoom();
            buildingCompany.BuildRoom();
            buildingCompany.BuildRoof();
        }
    }
}
