/*************************************************************************************************
  Required Notice: Copyright (C) EPPlus Software AB. 
  This software is licensed under PolyForm Noncommercial License 1.0.0 
  and may only be used for noncommercial purposes 
  https://polyformproject.org/licenses/noncommercial/1.0.0/

  A commercial license to use this software can be purchased at https://epplussoftware.com
 *************************************************************************************************
  Date               Author                       Change
 *************************************************************************************************
  01/27/2020         EPPlus Software AB       Initial release EPPlus 5
 *************************************************************************************************/
using System.Xml;

namespace OfficeOpenXml.Drawing
{
    /// <summary>
    /// Position of the a drawing.
    /// </summary>
    public class ExcelDrawingCoordinate : XmlHelper
    {
        internal delegate void SetWidthCallback();
        SetWidthCallback _setWidthCallback;
        internal ExcelDrawingCoordinate(XmlNamespaceManager ns, XmlNode node, SetWidthCallback setWidthCallback=null) :
            base(ns, node)
        {
            _setWidthCallback = setWidthCallback;
        }
        const string xPath = "@x";
        /// <summary>
        /// X coordinate in EMU
        /// 
        /// EMU units   1cm         =   1/360000 
        ///             1US inch    =   1/914400
        ///             1pt         =   1/12700
        ///             1pixel      =   1/9525
        /// </summary>
        public int X
        {
            get
            {
                return GetXmlNodeInt(xPath);
            }
            set
            {
                SetXmlNodeString(xPath, value.ToString());
                if(_setWidthCallback != null) _setWidthCallback();
            }
        }
        const string yPath = "@y";
        /// <summary>
        /// X coordinate in EMU
        /// 
        /// EMU units   1cm         =   1/360000 
        ///             1US inch    =   1/914400
        ///             1pt         =   1/12700
        ///             1pixel      =   1/9525
        /// </summary>
        public int Y
        {
            get
            {
                return GetXmlNodeInt(yPath);
            }
            set
            {
                SetXmlNodeString(yPath, value.ToString());
                if (_setWidthCallback != null) _setWidthCallback();
            }
        }
    }
}