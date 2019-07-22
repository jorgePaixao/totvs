using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TotvsPDV.Models;

namespace UnitTestPDV
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestCalculaTroco()
        {

            RegistroCaixa registro = new RegistroCaixa();

            registro.Produto = "1";
            registro.Valor = 153;
            registro.Dinheiro = 200;

            registro.CalculaTroco();

            foreach (string item in registro.TrocoDetalhado)
            {
                Assert.IsTrue(item.Contains("2") || item.Contains("14"));
            }            

        }


        [TestMethod]
        public void TestCalculaTroco2()
        {

            RegistroCaixa registro = new RegistroCaixa();

            registro.Produto = "1";
            registro.Valor = 110.35m;
            registro.Dinheiro = 200;

            registro.CalculaTroco();

            Assert.IsTrue(registro.TrocoDetalhado[0].Contains("50"));
            Assert.IsTrue(registro.TrocoDetalhado[1].Contains("20"));
            Assert.IsTrue(registro.TrocoDetalhado[2].Contains("10"));
            Assert.IsTrue(registro.TrocoDetalhado[3].Contains("50") && registro.TrocoDetalhado[3].Contains("19"));
            Assert.IsTrue(registro.TrocoDetalhado[4].Contains("10") && registro.TrocoDetalhado[4].Contains("1"));
            Assert.IsTrue(registro.TrocoDetalhado[5].Contains("5") && registro.TrocoDetalhado[5].Contains("1"));            

        }


        [TestMethod]
        public void TestCalculaTrocoErro()
        {

            RegistroCaixa registro = new RegistroCaixa();

            registro.Produto = "1";
            registro.Valor = 110.35m;
            registro.Dinheiro = 100;

            //registro.CalculaTroco();


            Assert.ThrowsException<Exception>(() => registro.CalculaTroco());

          
                     

        }

    }
}
