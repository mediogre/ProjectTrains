﻿using System;
using System.Collections.Generic;
using NUnit.Framework;
using System.Xml;
using System.IO;

namespace Trains
{
    public class Passenger
    {
        int             _id;
        string          _firstName;
        string          _lastName;
        public List<Ticket>    _tickets;

        /// <summary>
        /// Статический список всех пассажиров.
        /// </summary>
        //static List<Passenger> _allPassengers = new List<Passenger>();

        /// <summary>
        /// Инициализирует пассажира по номеру паспорта, имени, фамилии.
        /// Добавляет пассажира в список всех пассажиров. Создаёт пустой
        /// список билетов.
        /// </summary>
        /// <param name="ID">Номер паспорта.</param>
        /// <param name="FirstName">Имя.</param>
        /// <param name="LastName">Фамилия.</param>
        public Passenger(int ID, string FirstName, string LastName)
        {
            this.ID         = ID;
            this.FirstName  = FirstName;
            this.LastName   = LastName;
            this._tickets   = new List<Ticket>();
            List.AddToAllPassengers(this);
        }

        public void RemoveTicket(Ticket ticket)
        {
            this._tickets.Remove(ticket);
        }

        /// <summary>
        /// Создает XML-элемент "Passengers" с пассажирами, которые едут в данном поезде.
        /// </summary>
        /// <param name="xmlOut"></param>
        /// <param name="train"></param>
        public static void SavePassengersToFile(XmlTextWriter xmlOut, Train train)
        {
            xmlOut.WriteStartElement("Passengers");

            List<Ticket> tickets = train.Tickets;
            foreach(Ticket ticket in tickets)
            {
                ticket.Passenger.SaveToFile(xmlOut, train);
            }

            xmlOut.WriteEndElement();
        }

        /// <summary>
        /// Создает XML-элемент "Passenger" с данными о пасажире в нужном формате.
        /// </summary>
        /// <param name="xmlOut"></param>
        /// <param name="train"></param>
        public void SaveToFile(XmlWriter xmlOut, Train train)
        {
            xmlOut.WriteStartElement("Passenger");
            
            Ticket ticket = this.SearchTicketByTrain(train);

            xmlOut.WriteElementString("ID",             this.ID.ToString());
            xmlOut.WriteElementString("LName",          this.LastName);
            xmlOut.WriteElementString("FName",          this.FirstName);
            xmlOut.WriteElementString("TypeOfTicket",   ticket.Type);

            xmlOut.WriteEndElement();
        }

        private Ticket SearchTicketByTrainNumber(int trainNumber)
        {
            List<Ticket> tickets = this.Tickets;
            foreach(Ticket ticket in tickets)
            {
                if(ticket.Train.Number == trainNumber)
                {
                    return ticket;
                }
            }
            return null;
        }

        /// <summary>
        /// Возвращает ссылку на билет по данному поезду.
        /// </summary>
        /// <param name="train"></param>
        /// <returns></returns>
        private Ticket SearchTicketByTrain(Train train)
        {
            List<Ticket> tickets = this.Tickets;
            foreach(Ticket ticket in tickets)
            {
                if(ticket.Train == train)
                {
                    return ticket;
                }
            }
            return null;
        }


        /// <summary>
        /// Добавляет новый билет к уже имеющимся билетам пассажира.
        /// </summary>
        /// <param name="Ticket">Новый добавляемый билет.</param>
        public void AddTicket(Ticket Ticket)
        {
            this._tickets.Add(Ticket);
        }


        #region Поиск и связанные с ним методы

        /// <summary>
        /// Ищет пассажира по номеру паспорта. В случае успешного поиска возвращает
        /// пассажира. В случае провала возвращает null.
        /// </summary>
        /// <param name="ID">Номер паспорта.</param>
        /// <exception cref="KeyNotFoundException"></exception>
        public static Passenger Search(int ID)
        {
            foreach(Passenger Psg in List._allPassengers)
            {
                if (Psg.ID == ID)
                {
                    return Psg;
                }
            }
            return null;
        }


        /// <summary>
        /// Возвращает список пассажиров, удовлетворяющих
        /// параметрам поискового запроса.
        /// </summary>
        /// <param name="LName">Фамилия пассажира.</param>
        /// <param name="FName">Имя пассажира.</param>
        /// <param name="TypeOfTicket">Тип билета пассажира.</param>
        /// <returns>Список объектов класса Passenger.</returns>
        public static List<Passenger> Search(string LName, string FName, string TypeOfTicket)
        {
            List <Passenger> Psgs   = List._allPassengers;
            
            if (LName != "")
            {
                Psgs    = Passenger.SearchByLName(LName, Psgs);
            }

            if (FName != "")
            {
                Psgs    = Passenger.SearchByFName(FName, Psgs);
            }

            if (TypeOfTicket != "")
            {
                Psgs    = Passenger.SearchByTypeOfTicket(TypeOfTicket, Psgs);
            }

            return Psgs;
        }

        /// <summary>
        /// Возвращает список пассажиров с искомой фамилией.
        /// </summary>
        /// <param name="LName">Фамилия искомого пассажира.</param>
        /// <param name="Psgs">Список пассажиров, в котором проводится поиск.</param>
        /// <returns></returns>
        private static List<Passenger> SearchByLName(string LName, List<Passenger> Psgs)
        {
            List<Passenger> ResultPsgs  = new List<Passenger>();
            foreach(Passenger Psg in Psgs)
            {
                if (Psg.LastName == LName)
                    ResultPsgs.Add(Psg);
            }
            return ResultPsgs;
        }

        /// <summary>
        /// Возвращает список пассажиров с искомым именем.
        /// </summary>
        /// <param name="FName">Имя искомого пассажира.</param>
        /// <param name="Psgs">Список пассажиров, в котором проводится поиск.</param>
        /// <returns></returns>
        private static List<Passenger> SearchByFName(string FName, List<Passenger> Psgs)
        {
            List<Passenger> ResultPsgs  = new List<Passenger>();
            foreach(Passenger Psg in Psgs)
            {
                if (Psg.FirstName == FName)
                    ResultPsgs.Add(Psg);
            }
            return ResultPsgs;
        }


        /// <summary>
        /// Возвращает список пассажиров с искомым типом билета.
        /// </summary>
        /// <param name="TypeOfTicket">Тип билета искомого пассажира.</param>
        /// <param name="Psgs">Список пассажиров, в котором проводится поиск.</param>
        /// <returns></returns>
        private static List<Passenger> SearchByTypeOfTicket(string TypeOfTicket, List<Passenger> Psgs)
        {
            List<Passenger> ResultPsgs  = new List<Passenger>();
            foreach(Passenger Psg in Psgs)
            {
                if (Psg.ContainTypeOfTicket(TypeOfTicket))
                {
                    ResultPsgs.Add(Psg);
                }
            }
            return ResultPsgs;
        }

        /// <summary>
        /// Возвращает истину, если у пассажира имеется хотя бы
        /// один билет искомого типа.
        /// </summary>
        /// <param name="TypeOfTicket">Искомый тип билета.</param>
        /// <returns></returns>
        private bool ContainTypeOfTicket(string TypeOfTicket)
        {
            List<Ticket> Tcks   = this.Tickets;
            foreach (Ticket Tck in Tcks)
            {
                if (Tck.Type == TypeOfTicket)
                {
                    return true;
                }
            }
            return false;
        }

#endregion


        #region Свойства

        /// <summary>
        /// Возвращает номер паспорта.
        /// </summary>
        public int ID
        {
            get { return _id; }
            set { if ((value >= 1000) && (value <= 9999)) _id = value; }
        }

        /// <summary>
        /// Возвращает имя пассажира.
        /// </summary>
        public string FirstName
        {  
            get { return _firstName; }
            set { if (value.Length != 0) _firstName = value; }
        }

        /// <summary>
        /// Возвращает фамилию пассажира.
        /// </summary>
        public string LastName
        {  
            get { return _lastName; }
            set { if (value.Length != 0) _lastName = value; }
        }

        /// <summary>
        /// Возвращает список билетов, имеющихся у пассажира.
        /// </summary>
        public List<Ticket> Tickets { get {return _tickets;} }

        /// <summary>
        /// Возвращает количество билетов, имеющихся у пассажира.
        /// </summary>
        public int CountOfTickets { get { return Tickets.Count; } }

        /// <summary>
        /// Возвращает список всех пассажиров.
        /// </summary>
        //static List<Passenger> AllPassengers { get { return _allPassengers; } } 
    }

        #endregion

}

#region Тесты


    /*
    /// <summary>
    /// Класс с тестами для конструктора и свойств класса Passenger.
    /// </summary>
    [TestFixture]
    class TestPassenger
    {
        [Test]
        public static void TPassengerConstructor([Random(1000, 2000, 50)]                       int TNumber, 
                                                 [Values("Алёшина", "Румянцева", "Трофименко")] string TFirstName,
                                                 [Values("Анастасия", "Ксения", "Дарья")]       string TLastName,
                                                 [Values("Плацкарт", "Купе")]                   string TType)
        {
            Passenger TPassenger = new Passenger(TNumber, TFirstName, TLastName, TType);
        
            Assert.IsInstanceOf<Passenger>(TPassenger);
            Assert.AreEqual(TNumber, TPassenger.ID);
            Assert.AreEqual(TFirstName, TPassenger.FirstName);
            Assert.AreEqual(TLastName, TPassenger.LastName);
            Assert.AreEqual(TType, TPassenger.TypeOfTicket);
        }

        [Test]
        public static void TPassengerPropety([Random(-1000, 11000, 100)]                    int TNumber, 
                                             [Values("Алёшина", "Румянцева", "Трофименко")] string TFirstName,
                                             [Values("Анастасия", "Ксения", "Дарья")]       string TLastName,
                                             [Values("Плацкарт", "Купе")]                   string TType)
        {
            Passenger TPassenger = new Passenger(TNumber, TFirstName, TLastName, TType);
        
            if ((TNumber >= 1000) && (TNumber <=9999))
            { Assert.AreEqual(TNumber, TPassenger.ID); }
            else
            { Assert.AreEqual(0, TPassenger.ID); }
        }
    }
    */
#endregion
