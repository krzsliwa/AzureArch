
#TYDZIEN3.1 „Zbuduj prostą konwencję nazewniczą dla min. takich zasobów jak Grupa Zasobów, VNET, Maszyn Wirtualna, Dysk, Konta składowania danych. Pamiętaj o ograniczeniach w nazywaniu zasobów, które występują w Azure”

![initative](https://raw.githubusercontent.com/krzsliwa/AzureArch/master/ARM/policies/initative.png)

Definicje polityk przypisanych do inicjatywy znajdują się w folderze /policies.

  

Założenia:

1) Wszystkie nazwy powinny zawierać prefix "ks"

2) Grupy zasobów powinny zawierać prefix "ksrg"

3) Sieci wirtualne powinny zawierać prefix "ksVM"

4) Maszyny wirtualne powinny zawierać prefix "ksVNet"

  

#TYDZIEN3.2 „ Zbuduj prosty ARM Template (możesz wykorzystać już gotowe wzorce z GitHub), który wykorzystuje koncepcję Linked Templates. Template powinien zbudować środowisko złożone z jednej sieci VNET, podzielonej na dwa subnety. W każdy subnecie powinna powstać najprostsza maszyna wirtualna z systemem Ubuntu 18.04 a na każdym subnecie powinny zostać skonfigurowane NSG.”

  

i

  

#TYDZIEN3.4 „Spróbuj na koniec zmodyfikować template tak, by nazwa użytkownika i hasło do każdej maszyny z pkt. 2 było pobierane z KeyVault."

 

azuredeploy.json

  

deploy.azcli

 ![diagram](https://raw.githubusercontent.com/krzsliwa/AzureArch/master/ARM/diagram.png) 
 

#TYDZIEN3.3 „Zbuduj najprostrzą właśną rolę RBAC, która pozwala użytkownikowi uruchomić maszynę, zatrzymać ją i zgłosić zgłoszenie do supportu przez Portal Azure”

