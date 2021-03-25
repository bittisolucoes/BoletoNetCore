using System.Collections.Generic;
using System.Text;

namespace BoletoNetCore
{
    /// <summary>
    /// Classe representativa de um registro (linha) de um arquivo EDI
    /// </summary>
    public class TRegistroEDI
    {
        #region Vari�veis Privadas e Protegidas
        protected TTipoRegistroEDI _TipoRegistro;
        protected int _TamanhoMaximo = 0;
        protected char _CaracterPreenchimento = ' ';
        private string _LinhaRegistro;
        protected List<TCampoRegistroEDI> _CamposEDI = new List<TCampoRegistroEDI>();
        #endregion

        #region Propriedades
        /// <summary>
        /// Tipo de Registro da linha do arquivo EDI
        /// </summary>
        public TTipoRegistroEDI TipoRegistro
        {
            get { return _TipoRegistro; }
        }

        /// <summary>
        /// Seta a linha do registro para a decodifica��o nos campos;
        /// Obt�m a linha decodificada a partir dos campos.
        /// </summary>
        public string LinhaRegistro
        {
            get { return _LinhaRegistro; }
            set { _LinhaRegistro = value; }
        }

        /// <summary>
        /// Cole��o dos campos do registro EDI
        /// </summary>
        public List<TCampoRegistroEDI> CamposEDI
        {
            get { return _CamposEDI; }
            set { _CamposEDI = value; }
        }
        #endregion

        #region M�todos P�blicos
        public void Adicionar(TTiposDadoEDI tipo, int posicao, int tamanho, int decimais, object valor, char prenchimento)
        {
            CamposEDI.Add(new TCampoRegistroEDI(tipo, posicao, tamanho, decimais, valor, prenchimento));
        }

        /// <summary>
        /// Codifica uma linha a partir dos campos; o resultado ir� na propriedade LinhaRegistro
        /// </summary>
        public virtual void CodificarLinha()
        {
            var builder = new StringBuilder();
            foreach (TCampoRegistroEDI campos in _CamposEDI)
            {
                campos.CodificarNaturalParaEDI();
                builder.Append(campos.ValorFormatado);
            }
            _LinhaRegistro = builder.ToString();
        }

        /// <summary>
        /// Decodifica uma linha a partir da propriedade LinhaRegistro nos campos do registro
        /// </summary>
        public virtual void DecodificarLinha()
        {
            foreach (TCampoRegistroEDI campos in _CamposEDI)
            {
                if (_TamanhoMaximo > 0)
                {
                    _LinhaRegistro = _LinhaRegistro.PadRight(_TamanhoMaximo, _CaracterPreenchimento);
                }
                campos.ValorFormatado = _LinhaRegistro.Substring(campos.PosicaoInicial, campos.TamanhoCampo);
                campos.DecodificarEDIParaNatural();
            }
        }
        #endregion
    }
}