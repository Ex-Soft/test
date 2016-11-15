<?xml version="1.0" encoding="windows-1251"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
	<xsl:output method="html" doctype-public="-//W3C//DTD HTML 4.0 Transitional//EN" encoding="windows-1251" />
	<xsl:template match="/">
		<html>
			<head>
				<title><xsl:value-of select="StaffReport/ReportName"/></title>
			</head>
			<body>
				<p align="center"><strong><xsl:value-of select="StaffReport/ReportName"/></strong></p>
				<p align="center">N <xsl:value-of select="StaffReport/ReportNo"/></p>
				<p align="center">from <xsl:value-of select="StaffReport/ReportDate"/></p>
				<table border="1">
					<caption>Staff</caption>
					<thead>
						<tr>
							<th>Name</th>
							<th>BirthDate</th>
							<th>Salary</th>
						</tr>
					</thead>
					<tbody>
						<xsl:apply-templates select="StaffReport/Staff/Dep" />
					</tbody>
				</table>
				<hr />
				<table border="1">
					<caption>Staff II</caption>
					<thead>
						<tr>
							<th>Name</th>
							<th>BirthDate</th>
							<th>Salary</th>
						</tr>
					</thead>
					<tbody>
						<xsl:for-each select="StaffReport/Staff/Dep">
							<tr>
								<td align="center" colspan="3"><b>Depart# <xsl:value-of select="@DepNo" /></b></td>
								<xsl:for-each select="Name">
									<tr>
										<td><xsl:value-of select="text()" /></td>
										<td><xsl:value-of select="@BirthDate" /></td>
										<td><xsl:value-of select="@Salary" /></td>
									</tr>
								</xsl:for-each>
							</tr>
						</xsl:for-each>
					</tbody>
				</table>
			</body>
		</html>
	</xsl:template>

	<xsl:template match="Dep">
		<tr>
			<td align="center" colspan="3"><b>Depart# <xsl:value-of select="@DepNo" /></b></td>
			<xsl:apply-templates select="Name" />
		</tr>
	</xsl:template>

	<xsl:template match="Name">
		<tr>
			<td><xsl:value-of select="." /></td>
			<td><xsl:value-of select="@BirthDate" /></td>
			<td><xsl:value-of select="@Salary" /></td>
		</tr>
	</xsl:template>
</xsl:stylesheet>
