<?xml version="1.0" encoding="windows-1251"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:my="http://localhost/contract" xmlns:othersperson="http://localhost/othersperson">
	<xsl:output method="html" doctype-public="-//W3C//DTD HTML 4.0 Transitional//EN" encoding="windows-1251" />
	<xsl:template match="/">
		<html>
			<head>
				<title><xsl:value-of select="//my:contragent"/></title>
			</head>
			<body>
				<p><strong><xsl:value-of select="//my:contragent"/></strong></p>
				<p><xsl:value-of select="//my:date"/></p>
				<p><xsl:value-of select="//my:no"/></p>
				<table>
					<caption>Others Person I</caption>
					<thead>
						<tr>
							<th>Name</th>
							<th>BirthDate</th>
						</tr>
					</thead>
					<tbody>
						<xsl:apply-templates select="my:contract/othersperson:othersperson" />
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
						<xsl:for-each select="my:contract/othersperson:othersperson/othersperson:contragent">
							<tr>
								<td><xsl:value-of select="." /></td>
								<td><xsl:value-of select="@othersperson:date" /></td>
							</tr>
						</xsl:for-each>
					</tbody>
				</table>
			</body>
		</html>
	</xsl:template>

	<xsl:template match="othersperson:othersperson">
		<xsl:apply-templates select="othersperson:contragent" />
	</xsl:template>

	<xsl:template match="othersperson:contragent">
		<tr>
			<td><xsl:value-of select="." /></td>
			<td><xsl:value-of select="@othersperson:date" /></td>
		</tr>
	</xsl:template>
</xsl:stylesheet>
