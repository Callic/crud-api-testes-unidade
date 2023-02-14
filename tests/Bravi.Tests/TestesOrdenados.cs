using Bravi.Tests.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bravi.Tests
{
    //AQUI NESTE ATRIBUTO, NÓS DIZEMOS QUAL O NAMESPACE + O NOME DA CLASSE QUE IRÁ FAZER A ORDENAÇÃO E TAMBÉM EM QUAL NAMESPACE ELE IRÁ TRABALHAR
    [TestCaseOrderer("Bravi.Tests.Order.PriorityOrderer", "Bravi.Tests")]
    public class TestesOrdenados
    {
        public static bool Test1Called;
        public static bool Test2ACalled;
        public static bool Test3Called;
        public static bool Test4Called;

        [Fact(DisplayName = "Teste 4"), TestPriority(4)]
        [Trait("Categoria", "Teste Ordenação 4")]
        public void Test4()
        {
            Test3Called = true;

            Assert.True(Test1Called);
            Assert.True(Test2ACalled);
            Assert.True(Test3Called);
        }

        [Fact(DisplayName = "Teste 2"), TestPriority(2)]
        [Trait("Categoria", "Teste Ordenação 2")]
        public void Test2A()
        {
            Test2ACalled = true;

            Assert.True(Test1Called);
            Assert.False(Test3Called);
            Assert.False(Test4Called);
        }


        //QUANDO DEIXAMOS O TESTE SER UMA PRIORIDADE O VALOR ASSUMIDO POR ELE É O 0 E ELE SERÁ EXECUTADO LOGO EM SEGUIDA DOS ORDENADOS QUE TENHAM A PRIORIDADE <= 0
        [Fact(DisplayName = "Teste 3")]
        [Trait("Categoria", "Teste Ordenação 3")]
        public void Test3()
        {
            Test3Called = true;

            Assert.True(Test1Called);
            Assert.True(Test2ACalled);
            Assert.False(Test4Called);
        }

        [Fact(DisplayName = "Teste 1"), TestPriority(-1)]
        [Trait("Categoria", "Teste Ordenação 1")]
        public void Test1()
        {
            Test1Called = true;

            Assert.False(Test2ACalled);
            Assert.False(Test3Called);
            Assert.False(Test4Called);
        }
    }
}
