using System;
using System.Runtime.InteropServices.JavaScript;
using Xunit;

namespace POO
{
    //Write your code here

    #region Enonce
        public class Vehicle
        {
            public string Description = "";
            public string Type = "Vehicle";
        }

        public class Car : Vehicle
        {
            public Engine Engine;
            public Wheel Wheel;

            public Car(Engine engine, Wheel wheel)
            {
                Engine = engine;
                Wheel = wheel;
                Type = "Car";
                Description = "The Car has 45000 km.";
            }

            public Car()
            {
                Engine = new Engine();
                Wheel = new Wheel();
                Type = "Car";
                Description = "The Car has 45000 km.";
            }

            public void StartEngine()
            {
                Engine.Start();
            }

            public void Accelerate()
            {
                if (Engine.IsStarted != false)
                    Wheel.Turn();
            }

            public void Stop()
            {
                Engine.Stop();
                Wheel.Stop();
            }
        }

        public class Motorbike : Vehicle
        {
            public Motorbike()
            {
                Type = "Motorbike";
                Description = "The Motorbike has 7800 km.";
            }
        }

    #region Inheritance
    public class Inheritance
    {
        
        [Fact]
        public void Q01_Creer_une_classe_Vehicle_avec_un_champs_Type()
        {
            Vehicle vehicle = new Vehicle();
    
            Assert.Equal("Vehicle", vehicle.Type);
        }

    [Fact]
        public void Q02_Creer_une_classe_Car_heritant_de_Vehicle()
        {
            Car car = new Car();

            Assert.True(car is Vehicle);
        }

        [Fact]
        public void Q03_Verifier_la_valeur_du_champs_Type_d_un_objet_Car()
        {
            Vehicle car = new Car();

            Assert.Equal("Car", car.Type);
        }

        [Fact]
        public void Q04_Creer_un_champs_Description_indiquant_le_Mileage_du_Vehicle()
        {
            Vehicle car = new Car();

            string description = "The Car has 45000 km.";

            Assert.Equal(description, car.Description);
        }

        [Fact]
        public void Q05_Faire_de_meme_avec_une_classe_Motorbike()
        {
            Vehicle motorbike = new Motorbike();

            Assert.True(motorbike is Vehicle);
            Assert.Equal("Motorbike", motorbike.Type);
            Assert.Equal("The Motorbike has 7800 km.", motorbike.Description);
        }
    }
    #endregion

    public class Wheel
    {
        public bool IsTurning = false;

        public void Turn()
        {
            IsTurning = true;
        }

        public void Stop()
        {
            IsTurning = false;
        }
    }
    public class Engine
    {
        public bool IsStarted = false;
        public void Start()
        {
            IsStarted = true;
            Console.WriteLine("Vroom Vroom");
        }

        public void Stop()
        {
            IsStarted = false;
            Console.WriteLine("Goodbye");
        }
    }
    #region Composition
    public class Composition
    {
        
        [Fact]
        public void Q01_Creer_une_classe_Engine_qui_peut_demarrer_et_s_arreter()
        {
            Engine engine = new Engine();

            engine.Start();
            Assert.True(engine.IsStarted);

            engine.Stop();
            Assert.False(engine.IsStarted);
        }

    [Fact]
    public void Q02_Creer_une_classe_Wheel_qui_peut_tourner_et_s_arreter()
    {
        Wheel wheel = new Wheel();

        wheel.Turn();
        Assert.True(wheel.IsTurning);

        wheel.Stop();
        Assert.False(wheel.IsTurning);
    }

    [Fact]
    public void Q03_Ajouter_un_Engine_et_une_Wheel_a_la_classe_Car()
    {
        Engine engine = new Engine();
        Wheel wheel = new Wheel();
        Car car = new Car(engine, wheel);

        Assert.Equal(engine, car.Engine);
        Assert.Equal(wheel, car.Wheel);
    }

    [Fact]
    public void Q04_Ajouter_une_methode_pour_demarrer_le_moteur()
    {
        Engine engine = new Engine();
        Wheel wheel = new Wheel();
        Car car = new Car(engine, wheel);

        car.StartEngine();
        Assert.True(engine.IsStarted);
    }

    [Fact]
    public void Q05_Ajouter_une_methode_pour_accelerer_si_le_moteur_est_demarre()
    {
        Engine engine = new Engine();
        Wheel wheel = new Wheel();
        Car car = new Car(engine, wheel);

        car.Accelerate();
        Assert.False(wheel.IsTurning);

        car.StartEngine();
        car.Accelerate();
        Assert.True(wheel.IsTurning);
    }

    [Fact]
    public void Q06_Ajouter_une_methode_pour_arreter_le_moteur_et_la_roue()
    {
        Engine engine = new Engine();
        Wheel wheel = new Wheel();
        Car car = new Car(engine, wheel);

        car.StartEngine();
        car.Accelerate();
        car.Stop();

        Assert.False(engine.IsStarted);
        Assert.False(wheel.IsTurning);
    }
    }
    #endregion

    #region Polymorphism
    //public class Polymophism
    //{
    //    [Fact]
    //    public void Q01_Creer_une_classe_Fuel()
    //    {
    //        Fuel fuel = new Fuel(5);

    //        Assert.Equal(5, fuel.Value);
    //    }

    //    [Fact]
    //    public void Q02_Creer_une_classe_Consumption_possedant_une_methode_Estimate()
    //    {
    //        Consumption consumption = new Consumption();

    //        Fuel fuel = consumption.Estimate("Paris", "Nice");

    //        Assert.Equal(65, fuel.Value);
    //    }

    //    [Fact]
    //    public void Q03_Creer_une_deuxieme_methode_Estimate()
    //    {
    //        Consumption consumption = new Consumption();

    //        Distance distance = new Distance(100);
    //        Fuel fuel = consumption.Estimate(distance);

    //        Assert.Equal(7, fuel.Value);
    //    }

    //    [Fact]
    //    public void Q04_Creer_une_troisieme_methode_Estimate()
    //    {
    //        Consumption consumption = new Consumption();

    //        Fuel fuel = new Fuel(7);
    //        Distance distance = consumption.Estimate(fuel);

    //        Assert.Equal(100, distance.Value);
    //    }
    //}
    #endregion
    
    #endregion
}