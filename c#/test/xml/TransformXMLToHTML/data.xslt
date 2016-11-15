<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
	<xsl:output method="html" indent="yes" encoding="utf-8" />
	<xsl:template match="/">
		<html>
			<head>
				<title><xsl:value-of select="//contragent"/></title>
			</head>
			<body>
				<p><strong><xsl:value-of select="//contragent"/></strong></p>
				<p><xsl:value-of select="//date"/></p>
				<p><xsl:value-of select="//no"/></p>
				<table>
					<caption>Others Person I</caption>
					<thead>
						<tr>
							<th>Name</th>
							<th>BirthDate</th>
						</tr>
					</thead>
					<tbody>
						<xsl:apply-templates select="contract/othersperson" />
					</tbody>
				</table>
				<hr />
				<table>
					<caption>Others Person II</caption>
					<thead>
						<tr>
							<th>Name</th>
							<th>BirthDate</th>
						</tr>
					</thead>
					<tbody>
						<xsl:for-each select="contract/othersperson/contragent">
							<tr>
								<td><xsl:value-of select="." /></td>
								<td><xsl:value-of select="@date" /></td>
							</tr>
						</xsl:for-each>
					</tbody>
				</table>
			</body>
		</html>
	</xsl:template>

	<xsl:template match="othersperson">
		<xsl:apply-templates select="contragent" />
	</xsl:template>

	<xsl:template match="contragent">
		<tr>
			<td><xsl:value-of select="." /></td>
			<td><xsl:value-of select="@date" /></td>
		</tr>
	</xsl:template>
</xsl:stylesheet>
