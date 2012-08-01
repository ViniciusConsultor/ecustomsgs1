using ApplicationUtils.Utils;

namespace ApplicationUtils.ErrorReporting
{
	internal class ErrorReportXLST
	{
		public static void SaveToFile(string fileName)
		{
			FileUtils.SaveToFile(fileName, Content);
		}

		public static readonly string Content = @"<?xml version='1.0' encoding='utf-8'?>
<xsl:stylesheet version='1.0' xmlns:xsl='http://www.w3.org/1999/XSL/Transform'
    xmlns:msxsl='urn:schemas-microsoft-com:xslt' exclude-result-prefixes='msxsl'>

	<xsl:template match='/'>
		<html>
			<h1>Error report</h1>
			<body>
				<table border='0' width='50%'>
					<tr>
						<td>
							<a href='#Details'>1. Details</a>
						</td>
					</tr>
					<tr>
						<td>
							<a href='#Exceptions'>2. Exceptions</a>
						</td>
					</tr>
					<tr>
						<td>
							<a href='#Client_Info'>3. Client Additional Informations</a>
						</td>
					</tr>

					<tr>
						<td>
							<a href='#Server_Info'>4. Server Additional Informations</a>
						</td>
					</tr>

         <tr>
						<td>
							<a href='#ScreenCapture'>5. Client Screen Capture</a>
						</td>
					</tr>

					<tr>
						<td>
							<a href='#Client_Asm'>6. Assemblies loaded on client</a>
						</td>
					</tr>

					<tr>
						<td>
							<a href='#Server_Asm'>7. Assemblies loaded on server</a>
						</td>
					</tr>

					<tr>
						<td>
							<a href='#Profiling_info'>8. Promova usage profiling info</a>
						</td>
					</tr>
				</table>
				<a name='Details'>
					<h2>Details</h2>
				</a>
				<table border='0' width='50%'>
					<tr bgcolor='#DDDDDD'>
						<td align='left'>
							Location where the error was caught
						</td>
						<td align='left'>
							<xsl:value-of select='ServerErrorReport/ErrorLocation'/>
						</td>
					</tr>

					<tr bgcolor='#DDDDDD'>
						<td align='left'>Installation Name</td>
						<td align='left'>
							<xsl:value-of select='ServerErrorReport/AditionalInfo/InfoItem[@Key=""InstallationName""]'/>
						</td>
					</tr>

					<tr bgcolor='#DDDDDD'>
						<td align='left'>Product Version</td>
						<td align='left'>
							<xsl:value-of select='ServerErrorReport/AditionalInfo/InfoItem[@Key=""ProductVersion""]'/>
						</td>
					</tr>

					<tr bgcolor='#DDDDDD'>
						<td align='left'>Error Date</td>
						<td align='left'>
							<xsl:value-of select='ServerErrorReport/AditionalInfo/InfoItem[@Key=""ServerDate""]'/>
						</td>
					</tr>
				</table>
				<a name='Exceptions'>
					<h2>Exceptions were:</h2>
				</a>
				<xsl:apply-templates select='ServerErrorReport/ClientErrorReport/Exception'/>

				<a name='Client_Info'>
					<h2>Client additional informations</h2>
				</a>
				<table border='0' width='100%' >
					<tr bgcolor='#DDDDDD'>
						<th align='left'>Key</th>
						<th align='left'>Value</th>
					</tr>
					<xsl:for-each select='ServerErrorReport/ClientErrorReport/AditionalInfo/InfoItem'>
						<tr bgcolor='#DDDDDD'>
							<td>
								<xsl:value-of select='@Key'/>
							</td>
							<td>
								<xsl:value-of select='.'/>
							</td>
						</tr>
					</xsl:for-each>
				</table>

				<a name='Server_Info'>
					<h2>Server additional informations</h2>
				</a>
				<table border='0' width='100%'>
					<tr bgcolor='#DDDDDD'>
						<th align='left'>Key</th>
						<th align='left'>Value</th>
					</tr>
					<xsl:for-each select='ServerErrorReport/AditionalInfo/InfoItem'>
						<tr bgcolor='#DDDDDD'>
							<td>
								<xsl:value-of select='@Key'/>
							</td>
							<td>
								<xsl:value-of select='.'/>
							</td>
						</tr>
					</xsl:for-each>
					<tr bgcolor='#DDDDDD'>
						<td>Last Snapshot</td>
						<td>
							<xsl:value-of select='ServerErrorReport/LastSnapshot'/>
						</td>
					</tr>

					<tr bgcolor='#DDDDDD'>
						<td>Command Logs</td>
						<td>
							<table border='0' width='100%'>
								<xsl:for-each select='ServerErrorReport/CommandLogs/string'>
									<tr bgcolor='#DDDDDD'>
										<td>
											<xsl:value-of select='.'/>
										</td>
									</tr>
								</xsl:for-each>
							</table>
						</td>
					</tr>

				</table>

        <h2>Client Screen Capture</h2>

        <a name='ScreenCapture' href='Screenshot.png'><img src='Screenshot.png' height='200' width='266'/></a>
				<a name='ScreenCapture Gif' href='Screenshot.gif'><img src='Screenshot.gif' height='200' width='266'/></a>

        <a name='Client_Asm'>
					<h2>Assemblies loaded on client application domain</h2>
				</a>
				<table border='1'>
					<tr bgcolor='#9acd32'>
						<th align='left'>FullName</th>
						<th align='left'>CodeBase</th>
						<th align='left'>ImageVersion</th>
					</tr>
					<xsl:for-each select='ServerErrorReport/ClientErrorReport/LoadedAssemblies/AssemblyInfo'>
						<tr>
							<td>
								<xsl:value-of select='FullName'/>
							</td>
							<td>
								<xsl:value-of select='CodeBase'/>
							</td>
							<td>
								<xsl:value-of select='ImageVersion'/>
							</td>
						</tr>
					</xsl:for-each>
				</table>

				<a name='Server_Asm'>
					<h2>Assemblies loaded on server application domain</h2>
				</a>
				<table border='1'>
					<tr bgcolor='#9acd32'>
						<th align='left'>FullName</th>
						<th align='left'>CodeBase</th>
						<th align='left'>ImageVersion</th>
					</tr>
					<xsl:for-each select='ServerErrorReport/LoadedAssemblies/AssemblyInfo'>
						<tr>
							<td>
								<xsl:value-of select='FullName'/>
							</td>
							<td>
								<xsl:value-of select='CodeBase'/>
							</td>
							<td>
								<xsl:value-of select='ImageVersion'/>
							</td>
						</tr>
					</xsl:for-each>
				</table>

				<a name='Profiling_info'>
					<h2>Promova usage profiling information</h2>
				</a>
        <p>Profiling starting date: <xsl:value-of select='ServerErrorReport/PromovaProfilingData/ProfilingStartingDate'/></p>
				<table border='1'>
					<tr bgcolor='#9acd32'>
						<th align='left'>ToolName</th>
						<th align='left'>MinutesOfUsage</th>
						<th align='left'>EnterCounter</th>
						<th align='left'>Commands (CallsCounter / Procesor Time)</th>
						<th align='left'>Queries (Calls Counter / Procesor Time)</th>
					</tr>
					<xsl:for-each select='ServerErrorReport/PromovaProfilingData/List/XmlSerializableToolProfilingData'>
						<tr>
							<td>
								<xsl:value-of select='ToolName'/>
							</td>
							<td>
								<xsl:value-of select='MinutesOfUsage'/>
							</td>
							<td>
								<xsl:value-of select='EnterCounter'/>
							</td>
							<td>
								<table>
									 <xsl:for-each select='CommandsCallsCount/SerializableServerMethodCallProfilingData'>
										<tr>
											<td>
												<xsl:value-of select='CommandName'/>
											</td>
											<td>
												<xsl:value-of select='CallsCounter'/>
											</td>
											<td>
												<xsl:value-of select='ProcessorTime'/>
											</td>
										</tr>
									</xsl:for-each>
									
								</table>
							</td>
							<td>
								<table>
									<xsl:for-each select='QueriesCallsCount/SerializableServerMethodCallProfilingData'>
										<tr>
											<td>
												<xsl:value-of select='CommandName'/>
											</td>
											<td>
												<xsl:value-of select='CallsCounter'/>
											</td>
											<td>
												<xsl:value-of select='ProcessorTime'/>
											</td>
										</tr>
									</xsl:for-each>

								</table>
							</td>
						</tr>
					</xsl:for-each>
				</table>
			</body>
		</html>
	</xsl:template>

	<xsl:template match='Exception'>
		<table border='0'>
			<tr bgcolor='#ccff99'>
				<td >
					<b>Exception message:</b>
				</td>
			</tr>
			<tr bgcolor='#ccff99'>
				<td>
					<span style='color:Red'>
						<xsl:value-of select='ErrorMesssage'/>
					</span>
				</td>
			</tr>

			<tr bgcolor='#ccff99'>
				<td>
					<b>Stack Trace:</b>
				</td>
			</tr>
			<tr bgcolor='#ccff99'>
				<td>
         <pre>
 				  	<xsl:value-of select='StackTrace'/>
          </pre>
				</td>
			</tr>

			<tr>
				<td>
					<table width='100%'>
						<tr>
							<td></td>
							<td>
								<xsl:apply-templates select='./InnerExpcetion'/>
							</td>
						</tr>
					</table>
				</td>
			</tr>
		</table>
	</xsl:template>

	<xsl:template match='InnerExpcetion'>
		<table border='0' width='100%'>
			<tr bgcolor='#ccff99'>
				<td >
					<b>Inner exception message:</b>
				</td>
			</tr>
			<tr bgcolor='#ccff99'>
				<td>
					<span style='color:Red'>
						<xsl:value-of select='ErrorMesssage'/>
					</span>
				</td>
			</tr>
			<xsl:if test='StackTrace'>
				<tr bgcolor='#ccff99'>
					<td>
						<b>Stack Trace:</b>
					</td>
				</tr>
				<tr bgcolor='#ccff99'>
					<td>
            <pre>  
						   <xsl:value-of select='StackTrace'/>
            </pre>
					</td>
				</tr>
			</xsl:if>

			<tr>
				<td>
					<table width='100%'>
						<tr>
							<td></td>
							<td>
								<xsl:apply-templates select='./InnerExpcetion'/>
							</td>
						</tr>
					</table>
				</td>
			</tr>
		</table>
	</xsl:template>

</xsl:stylesheet>

";
	}
}