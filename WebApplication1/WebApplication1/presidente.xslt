<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" >
  <xsl:output method="xml" indent="yes"/>

  <xsl:template match="Presidente">

    <Presidentes>
      <Presidente>

        <xsl:attribute name="ID">
          <xsl:value-of select="@ID"/>
        </xsl:attribute>

        <xsl:attribute name="Imagem">
          <xsl:value-of select="image"/>
        </xsl:attribute>

        <xsl:attribute name="Nome">
          <xsl:value-of select="nome"/>
        </xsl:attribute>

        <xsl:attribute name="Nascimento">
          <xsl:value-of select="nascimento"/>
        </xsl:attribute>

        <xsl:attribute name="Inicio_Mandato">
          <xsl:value-of select="inicio"/>
        </xsl:attribute>

        <!-- Private Info -->

        <xsl:attribute name="Fim_Mandato">
          <xsl:value-of select="fim"/>
        </xsl:attribute>

        <xsl:attribute name="Morte">
          <xsl:value-of select="morte"/>
        </xsl:attribute>

        <xsl:attribute name="Partidos">
          <xsl:value-of select="partidos"/>
        </xsl:attribute>

        <xsl:attribute name="Esposa">
          <xsl:value-of select="esposa"/>
        </xsl:attribute>

      </Presidente>
    </Presidentes>
       
  </xsl:template>
</xsl:stylesheet>
