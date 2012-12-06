﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace Trains
{

    class Station
    {
        string   _name;
        int      _x;
        int      _y;

        /// <summary>
        /// инициализирует станцию по её названию и координатам на форме.
        /// </summary>
        /// <param name="Name">Название станции.</param>
        /// <param name="X">Координата X на форме.</param>
        /// <param name="Y">Координата Y на форме.</param>
        public Station(string Name, int X, int Y)
        {
            _name    = Name;
            _x       = X;
            _y       = Y;
        }

        /// <summary>
        /// Возвращает название станции.
        /// </summary>
        public string Name { get { return _name; } }     

        /// <summary>
        /// Возвращает координату X станции на форме.
        /// </summary>
        public int X { get { return _x; } }

        /// <summary>
        /// Возвращает координату Y станции на форме.
        /// </summary>
        public int Y { get { return _y; } }
    }

    class Data
    {
        static List<Station> _allStations;
        static List<Station> AllStations { get { return _allStations; } }

        /// <summary>
        /// Добавляет местоположение станции в оперативную память
        /// для дальнейшей работы.
        /// </summary>
        /// <param name="Station">Местоположение станции.</param>
        private static void AddToAllStations(Station Station)
        {
            _allStations.Add(Station);
        }

        public static Station Search(string Name)
        {
            foreach (Station Stn in AllStations)
            {
                if (Stn.Name == Name)
                {
                    return Stn;
                }
            }
            return null;
        }

        /// <summary>
        /// Загружает все данные из XML-документа в оперативную память для дальнейшей работы.
        /// </summary>
        /// <param name="FileName">Путь к XML-документу.</param>
        public static void LoadFromFile(string FileName)
        {
            XmlDocument doc         = new XmlDocument();
            doc.Load(FileName);
            
            XmlNode     root        = doc.DocumentElement;
            XmlNodeList stations    = root.ChildNodes[0].ChildNodes;
            XmlNodeList trains      = root.ChildNodes[1].ChildNodes;

            AddStations (stations);
            AddTrains   (trains);
        }


        /// <summary>
        /// Добавляет данные о местоположениях станций в программу.
        /// </summary>
        /// <param name="Stations">Список узлов типа Location.</param>
        private static void AddStations(XmlNodeList Stations)
        {
            foreach(XmlNode Stn in Stations)
            {
                string  name    = Stn.ChildNodes[0].InnerText;
                int     x       = Convert.ToInt32(Stn.ChildNodes[1].InnerText);
                int     y       = Convert.ToInt32(Stn.ChildNodes[2].InnerText);

                Station Station = new Station(name, x, y);
                AddToAllStations(Station);
            }
        }

        /// <summary>
        /// Добавляет данные о поездах в оперативную память.
        /// </summary>
        /// <param name="Trains">Список узлов типа Train.</param>
        private static void AddTrains(XmlNodeList Trains)
        {
            foreach(XmlNode Trn in Trains)
            {
                int         Number      = Convert.ToInt32(Trn.ChildNodes[0].InnerText);
                XmlNodeList RouteNodes  = Trn.ChildNodes[1].ChildNodes;
                XmlNodeList Passengers  = Trn.ChildNodes[2].ChildNodes;

                Train Train = new Train(Number);

                AddRouteNodes   (Train, RouteNodes);
                AddPassengers   (Train, Passengers);
            }
        }

        /// <summary>
        /// Добавляет данные о станциях в оперативную память и
        /// добавляет станции к маршруту поезда.
        /// </summary>
        /// <param name="NumberOfTrain">Номер поезда.</param>
        /// <param name="Stations">Список узлов типа Station.</param>
        private static void AddRouteNodes(Train Train, XmlNodeList Stations)
        {
            foreach(XmlNode Stn in Stations)
            {
                string      name            = Stn.ChildNodes[0].InnerText;
                string      timeOfDeparture = Stn.ChildNodes[1].InnerText;
                string      timeOfArrival   = Stn.ChildNodes[2].InnerText;
                Station     station         = Search(name);
                RoteNode    routenode       = new RoteNode(station, timeOfDeparture, timeOfArrival);
                Train.AddRouteNodeToTrain(routenode);     
            }
        }

        /// <summary>
        /// Добавляет данные о пассажирах в программу и устанавливает связь 
        /// между поездами и пассажирами.
        /// </summary>
        /// <param name="Train">Поезд, в который добавляюся пассажиры из списка узлов.</param>
        /// <param name="Passengers">Список узлов типа Passenger.</param>
        private static void AddPassengers(Train Train, XmlNodeList Passengers)
        {
            foreach(XmlNode Psg in Passengers)
            {
                int     ID              = Convert.ToInt32(Psg.ChildNodes[0].InnerText);
                string  TypeOfTicket    = Psg.ChildNodes[3].InnerText;
                Ticket  Ticket          = new Ticket(Train, TypeOfTicket);
                Passenger PAS           = Passenger.Search(ID);

                if (PAS != null)
                {
                    Passenger.AddTicketToPassengerByID(ID, Ticket); 
                }
                else
                {
                    string  LName   = Psg.ChildNodes[1].InnerText;
                    string  FName   = Psg.ChildNodes[2].InnerText;
                    PAS             = new Passenger(ID, FName, LName, Ticket);
                }

                Train.AddPassengerToTrain(PAS, Train);
            }
        }
    }
}
