<?xml version="1.0" encoding="windows-1251"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
	<xsl:output method="html" doctype-public="-//W3C//DTD HTML 4.0 Transitional//EN" encoding="windows-1251" />
	<xsl:template match="root">
		<html>
			<head>
				<title>Test &lt;if&gt;</title>
			</head>
			<body>
				<xsl:for-each select="item/value1">
					<xsl:if test="@id &lt; 20">
						<font xsl:use-attribute-sets="attribute-value1">
							<xsl:value-of select="@id" />&#xa0;
						</font>
					</xsl:if>
					<xsl:if test="@id &lt; 30">
						<font xsl:use-attribute-sets="attribute-value2">
							<xsl:value-of select="@id" />&#xa0;
						</font>
					</xsl:if>
					<xsl:if test="@id=31">
						<font xsl:use-attribute-sets="attribute-value3">
							<xsl:value-of select="@id" />&#xa0;
						</font>
					</xsl:if>
					<xsl:if test="@id=41">
						<font xsl:use-attribute-sets="attribute-value4">
							<xsl:value-of select="@id" />&#xa0;
						</font>
					</xsl:if>
					<xsl:value-of select="." /><br />
				</xsl:for-each>
				<hr/>
				<xsl:for-each select="item/value2">
					<xsl:if test="@idc='b'">
						<font xsl:use-attribute-sets="attribute-value1">
							<xsl:value-of select="@idc" />&#xa0;
						</font>
					</xsl:if>
					<xsl:if test="@idc='bb'">
						<font xsl:use-attribute-sets="attribute-value2">
							<xsl:value-of select="@idc" />&#xa0;
						</font>
					</xsl:if>
					<xsl:if test="@idc='bbb'">
						<font xsl:use-attribute-sets="attribute-value3">
							<xsl:value-of select="@idc" />&#xa0;
						</font>
					</xsl:if>
					<xsl:if test="@idc='bbbb'">
						<font xsl:use-attribute-sets="attribute-value4">
							<xsl:value-of select="@idc" />&#xa0;
						</font>
					</xsl:if>
					<xsl:value-of select="." /><br />
				</xsl:for-each>
				<hr/>
				<xsl:for-each select="item/value3">
					<xsl:if test="@idn &lt; 20">
						<font xsl:use-attribute-sets="attribute-value1">
							<xsl:value-of select="@idn" />&#xa0;
						</font>
					</xsl:if>
					<xsl:if test="@idn &lt; 30">
						<font xsl:use-attribute-sets="attribute-value2">
							<xsl:value-of select="@idn" />&#xa0;
						</font>
					</xsl:if>
					<xsl:if test="@idn=33">
						<font xsl:use-attribute-sets="attribute-value3">
							<xsl:value-of select="@idn" />&#xa0;
						</font>
					</xsl:if>
					<xsl:if test="@idn=43">
						<font xsl:use-attribute-sets="attribute-value4">
							<xsl:value-of select="@idn" />&#xa0;
						</font>
					</xsl:if>
					<xsl:value-of select="." /><br />
				</xsl:for-each>
				<hr/>
				<xsl:if test="count(item/value3[@id=33 and @idc='ccc' and @idn=33])=1">
					oB!
				</xsl:if>
			</body>
		</html>
	</xsl:template>

	<xsl:attribute-set name="attribute-value1">
		<xsl:attribute name="size">-1</xsl:attribute>
		<xsl:attribute name="color">red</xsl:attribute>
		<xsl:attribute name="face">Tahoma</xsl:attribute>
	</xsl:attribute-set>

	<xsl:attribute-set name="attribute-value2">
		<xsl:attribute name="size">+1</xsl:attribute>
		<xsl:attribute name="color">blue</xsl:attribute>
		<xsl:attribute name="face">Verdana</xsl:attribute>
	</xsl:attribute-set>

	<xsl:attribute-set name="attribute-value3">
		<xsl:attribute name="size">+3</xsl:attribute>
		<xsl:attribute name="color">green</xsl:attribute>
		<xsl:attribute name="face">Comic Sans MS</xsl:attribute>
	</xsl:attribute-set>

	<xsl:attribute-set name="attribute-value4">
		<xsl:attribute name="size">+5</xsl:attribute>
		<xsl:attribute name="color">yellow</xsl:attribute>
		<xsl:attribute name="face">System</xsl:attribute>
	</xsl:attribute-set>

</xsl:stylesheet>
