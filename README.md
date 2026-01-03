Acest proiect reprezinta un sistem de gestiune a donatiilor pentru ONG-uri. Aplicatia permite gestionarea campaniilor de fudraising si a donatiilor realizate de utilizatori. Proiectul este structurat pe principii POO si DDD( Domain-Driven Design). 
Am fost responsabila de modelarea domeniului aplicatiei, incluzand:
      -definirea entitatilor;
      -definirea ValueObjects;
      -implementarea regulilor de business;
      -realizarea agregatelor;
      -tratarea exceptiilor de domeniu;
Aceasta parte este complet independenta de interfata, persistenta datelor sau infrastructura. Reprezinta nucleul aplicatiei si va fi utilizata de celelalte module pentru persistenta datelor,interfata utilizator,logare si configurare. 

Structura Domain-ului:
1)ValueObjects:

  ValueObject-urile sunt imutabile si contin validari.
    -Money:reprezinta o suma de bani(doar valori pozitive);
    -Email:valideaza formatul unui email;
    -CampaignId,DonationId,UserId-identificatori unici bazati pe Guid
    -Category:enum pentru tipurile de campanii(Education, Health, Environment, Social;

    
2)Entities:




3)Aggregates:




4)Exceptions:
    -DomainException:exceptie specifica domeniului, utilizata pentru validarea regulilor de business;


