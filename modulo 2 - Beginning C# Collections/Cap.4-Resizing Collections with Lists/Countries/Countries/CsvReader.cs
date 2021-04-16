using System;
using System.IO;
using System.Collections.Generic;

namespace Countries
{
    class CsvReader
    {
        #region Field
        //var irá informar o caminho da fonte de dados
        private string _csvFilePath;
        #endregion

        #region Methods

        /// <summary>
        /// Este método espera receber o caminho do arquivo CSV
        /// </summary>
        /// <param name="csvFilePath"></param>
        public CsvReader(string csvFilePath)
        {
            this._csvFilePath = csvFilePath;
        }


        /// <summary>
        /// Este método lê todos os países do arquivo e retorna os dados de cada país
        /// <para> Apenas irá parar de lê o arquivo quando o conteudo for nulo(sem itens)</para>
        /// </summary>
        /// <param name="nCountries"></param>
        /// <returns></returns>
        public List<Country> ReadAllCountries()
        {
            List<Country> countries = new List<Country> ();

            using (StreamReader sr = new StreamReader(_csvFilePath)) 
            {
                sr.ReadLine(); // linha do cabeçalho

                string csvLine;
                while ((csvLine = sr.ReadLine()) != null)
                {
                  countries.Add(ReadCountryFromCsvLine(csvLine));
                }
            
            }                      
            return countries;
        }


        /// <summary>
        /// Este método recebe como argumento  o dado de cada linha do arquivo CSV referente a um país
        /// </summary>
        /// <param name="csvLine"></param>
        /// <returns></returns>
        public Country ReadCountryFromCsvLine(string csvLine)
        {
            string[] parts = csvLine.Split(',');
            string name, code, region, text;

            switch(parts.Length)
            {
                case 4: // paises com um único nome
                    name = parts[0];
                    code = parts[1];
                    region = parts[2];
                    text = parts[3];
                    break;
                case 5: //paises com nome  composto 
                    name = parts[0] + ","+ parts[1];
                    name = name.Replace("\"", null).Trim();//remove as aspas-duplas
                    code = parts[2];
                    region = parts[3];
                    text = parts[4];
                    break;
                default:
                    throw new Exception($"Can't parse country from file: {csvLine}");
            }

            //if population be unknown will return 0
            int.TryParse(text,out int population);
            return new Country(name, code, region, population);

        }



        #endregion
    }
}
