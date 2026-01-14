Acest proiect reprezinta un sistem de gestiune a donatiilor pentru ONG-uri. Aplicatia permite gestionarea campaniilor de fudraising si a donatiilor realizate de utilizatori. Proiectul este structurat pe principii POO si DDD( Domain-Driven Design). 
Am fost responsabila de modelarea domeniului aplicatiei, incluzand:definirea entitatilor, definirea ValueObjects, implementarea regulilor de business, realizarea agregatelor,tratarea exceptiilor de domeniu;
Aceasta parte este complet independenta de interfata, persistenta datelor sau infrastructura. Reprezinta nucleul aplicatiei si va fi utilizata de celelalte module pentru persistenta datelor,interfata utilizator,logare si configurare. 

Structura Domain-ului:

1)ValueObjects:

  ValueObject-urile sunt imutabile si contin validari. Money reprezinta o suma de bani(doar valori pozitive).Email valideaza formatul unui email. CampaignId,DonationId,UserId sunt identificatori unici bazati pe Guid. Category:enum pentru tipurile de campanii(Education, Health, Environment, Social;
    
2)Entities:

Toate entitatile folosesc proprietati cu setteri privati sau doar cu get, asigurand incapsularea completa. Modificarea starii interne se face exclusiv prin metode autorizate. User(clasa abstracta) reprezinta baza sistemului de utilizatori. Este marcata ca abstract pentru a preveni instantierea directa, impunand validari esentiale(ex: numele nu poate fi gol) pentru orice tip de utilizator.
AdminONG este o entitate specializata care mosteneste clasa User. Are responsabilitatea de a gestiona campaniile de fundraising si de a urmari donatiile primite, avand in plus proprietatea OrganizationName.
Donator reprezinta persoana fizica ce contribuie la cauze. Aceasta entitate permite urmarirea istoricului personal de donatii si vizualizarea impactului acestora.
Donation: eveniment unic de transfer financiar intre un donator si o campanie. include informatii despre suma, data realizari si identitatea donatorului, fiind imutabila.

3)Aggregates:

Entitatea Campaign actioneaza ca un Aggregate Root. Aceasta gestioneaza intern colectia de donatii si garanteaza integritatea datelor prin metode de control precum AddDonation().
Contine logica de business care inchide automat campania atunci cand obiectivul financiar (TargetAmount) a fost atins.

4)Exceptions:

DomainException:este o exceptie specifica domeniului, utilizata pentru validarea regulilor de business;

5) Services

  Serviciile reprezintă logica de business aplicată pe entități și agregate. Acestea utilizează entitățile și Value Object-urile definite anterior și permit manipularea și interogarea datelor, respectând regulile domeniului. Fiecare serviciu este responsabil pentru un set clar de funcționalități și se ocupă exclusiv de procesarea logică, fără a avea legături cu persistenta datelor, interfața utilizator sau infrastructura externă.

  *AuthenticationService*
  
AuthenticationService gestionează autentificarea și sesiunea utilizatorilor.
Metoda Authenticate verifică existența unui utilizator și îl setează ca utilizator curent, aplicând validările necesare (email obligatoriu, user existent).
Logout resetează utilizatorul curent, iar IsAdminLoggedIn permite verificarea rapidă a rolului utilizatorului.
Serviciul utilizează ILogger pentru logarea acțiunilor critice, asigurând monitorizarea accesului și a activităților utilizatorilor.
Evoluția aplicației depinde de autentificare, deoarece toate celelalte funcționalități se bazează pe identificarea corectă a utilizatorilor și pe controlul rolurilor acestora.

  *CampaignService*
  
CampaignService gestionează campaniile de fundraising și comunicarea lor.
Permite crearea de campanii noi prin CreateCampaign, cu validări privind suma minimă și categoria campaniei.
Oferă posibilitatea filtrării campaniilor după categorie (GetCampaignsByCategory) sau stare (FindCampaignsByState).
Adminii pot marca campaniile ca închise (MarkCampaign) și pot adăuga actualizări privind progresul campaniei (AddCampaignUpdate).
Serviciul asigură integritatea datelor prin logarea tuturor acțiunilor și respectă principiul Single Responsibility, concentrându-se exclusiv pe gestionarea campaniilor.
În evoluția aplicației, acest serviciu permite monitorizarea activităților campaniilor și furnizarea de informații transparente pentru donatori și admini.

  *DonationService*
  
DonationService se ocupă cu procesarea și urmărirea donațiilor realizate de utilizatori.
ProcessDonation permite gestionarea donațiilor unice sau recurente, aplicând validări privind donatorul, campania și suma.
Serviciul trimite confirmări de donație (SendThankYou) și păstrează loguri detaliate despre fiecare tranzacție.
Metodele GetAllDonations și GetDonationHistorybyDonor oferă vizibilitate asupra tuturor donațiilor și istoricului individual al fiecărui donator.
Prin acest serviciu, aplicația asigură trasabilitatea donațiilor și transparența fluxului financiar.

  *ReportService*
  
ReportService generează rapoarte de impact și documente oficiale pentru campanii și donatori.
GetSumByCategory calculează totalul sumelor donate pentru o categorie de campanii.
ImpactReport creează mesaje descriptive despre efectele donațiilor, adaptate la tipul campaniei (Educație, Sănătate, Mediu, Social).
GetDocumentConfiguration produce confirmări oficiale pentru donatori, incluzând detalii despre campanie, sumă și data donației.
Serviciul contribuie la transparență și credibilitate, oferind informații concrete despre modul în care donațiile au fost utilizate.

  *UserService*
UserService permite monitorizarea activităților utilizatorilor și a donatorilor.
TrackCampaign returnează toate campaniile în care un utilizator a contribuit, facilitând vizualizarea implicării individuale.
TrackDonation permite adminilor să obțină lista tuturor donatorilor, păstrând controlul asupra accesului la date.
Serviciul consolidează funcționalitatea aplicației prin urmărirea implicării utilizatorilor și oferă suport pentru analiza și raportarea activităților.

