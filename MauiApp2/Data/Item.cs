﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MauiApp2.Data
{
	public class Item : IItems
	{
		public TypVek Vek = TypVek.Dospely;
		public TypKontainera Kontainer = TypKontainera.Bez;
		public bool MaVratKus = false;
		public bool Pohlavie = false;       //false - muz / true - zena
		public bool Pokladna = false;       //false - samoobsluha / true - pokladna
		public bool Pecivo = false;
		public bool Voda = false;
		public bool Alkohol = false;
		public bool Drogeria = false;
		public bool Maso = false;
		public DateTime DatumVstupDoSystemu = DateTime.Now;
		public DateTime CasCelkovy = new DateTime(2000, 1, 1, 0, 0, 0); //Casomiera MAX jeden den, inak reset
		public DateTime CasVozik = new DateTime(2000, 1, 1, 0, 0, 0);
		public DateTime CasVRade = new DateTime(2000, 1, 1, 0, 0, 0);
		public DateTime CasZaPokladnou = new DateTime(2000, 1, 1, 0, 0, 0);
		public DateTime DatumVystupuOdSystemu = DateTime.Now;
		//public DateTime CasVRadeZaVratnouStanicou = new DateTime(2000, 1, 1, 0, 0, 0);
		public DateTime CasZaVratnouStanicou = new DateTime(2000, 1, 1, 0, 0, 0);
		public List<string> MoznostiNakupu = new List<string>();     //{ "Pecivo", "Voda", "Alkohol", "Drogeria", "Maso" }

		public bool Ulozene = false;
		public string FarbaVlasov = "#FFFFFF";
		public string FarbaOblecenia = "Noh:\nObl:\nVla:";
		public bool[] CasManager = new bool[5] {true, false, false, false, false };         //tolko kolko mame DateTime casovacov, treba si pamatat poradie (aktualne tak ako su za sebou napisane)

		public void Namerany() {
			Ulozene = true;
			DatumVystupuOdSystemu = DateTime.Now;
		}

		public string GetCsvZaznam() {      //vrati zaznam oddeleny ';' + enter

			if (MoznostiNakupu.Count != 0) {
				if (MoznostiNakupu.Contains("Pecivo")) {
					Pecivo = true;
				}
				if (MoznostiNakupu.Contains("Voda"))
				{
					Voda = true;
				}
				if (MoznostiNakupu.Contains("Alkohol"))
				{
					Alkohol = true;
				}
				if (MoznostiNakupu.Contains("Drogeria"))
				{
					Drogeria = true;
				}
				if (MoznostiNakupu.Contains("Maso"))
				{
					Maso = true;
				}
			}

			return DatumVstupDoSystemu.ToString("dd.MM.yyyy HH:mm:ss") + ";" + CasCelkovy.ToString("HH:mm:ss") + ";" + CasVozik.ToString("HH:mm:ss") + ";" + CasVRade.ToString("HH:mm:ss") + ";"
				+ CasZaPokladnou.ToString("HH:mm:ss") + ";" + CasZaVratnouStanicou.ToString("HH:mm:ss") + ";" + DatumVystupuOdSystemu.ToString("dd.MM.yyyy HH:mm:ss") + ";" + Pohlavie + ";" + Vek + ";"
				+ Kontainer + ";" + MaVratKus + ";" + Pokladna + ";" + Pecivo + ";" + Voda + ";" + Alkohol + ";" + Drogeria + ";" + Maso + "\n";
		}
	}
}
