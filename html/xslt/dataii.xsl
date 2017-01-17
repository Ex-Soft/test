<?xml version="1.0" encoding="windows-1251"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
<xsl:output method="html" encoding="windows-1251" />
  <xsl:template match="Items">
    <table border="1">
      <xsl:call-template name="showRow"/>
    </table>
  </xsl:template>

  <xsl:template match="item">
    <xsl:apply-templates select="*"/>
  </xsl:template>

  <xsl:template match="*">
    <td>
      <xsl:value-of select="."/>
    </td>
  </xsl:template>

  <xsl:template name="showRow">
    <xsl:param name="idx" select="1"/>
    <xsl:variable name="numRow" select="10"/>  <!-- количество строк в столбце -->
    <tr>
      <xsl:apply-templates select="item[position() mod $numRow = $idx]"/>
    </tr>
    <xsl:if test="$idx != 0">
      <xsl:call-template name="showRow">
        <xsl:with-param name="idx" select="($idx + 1) mod $numRow"/>
      </xsl:call-template>
    </xsl:if>
  </xsl:template>

</xsl:stylesheet>
