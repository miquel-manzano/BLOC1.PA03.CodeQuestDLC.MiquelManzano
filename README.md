# BLOC1.PA03.CodeQuestDLC.MiquelManzano

## 🎯 Descripció General

Un joc de rol RPG per consola en C# anomenat CodeQuest, on el jugador controla un mag que pot entrenar, pujar de nivell, aconseguir recursos, comprar objectes i desxifrar pergamins antics.
El joc té un menú principal amb 7 opcions funcionals més l'opció de sortir.

**Capítols (funcionalitats)**

* **Capítol 1 — Train your wizard**: Entrenar el mag.
* **Capítol 2 — Increase LVL**: Combatre i pujar de nivell.
* **Capítol 3 — Loot the mine**: Minar per aconseguir bits (moneda del joc).
* **Capítol 4 — Show inventory**: Mostrar inventari.
* **Capítol 5 — Buy items**: Comprar objectes.
* **Capítol 6 — Show attacks**: Veure atacs disponibles segons el nivell.
* **Capítol 7 — Decode ancient Scroll**: Desxifrar pergamins màgics.

---

# Joc de proves (Test Cases)

### Menú general (precondicions)

| # Instrucció | # Iteració | Variables                 | Condició | Resultat esperat                                                |
| -----------: | ---------: | ------------------------- | -------- | --------------------------------------------------------------- |
|         Menu |          - | op = 1, validInput = true | -        | Mostra el menú i entra al `case 1` quan l'usuari introdueix `1` |
|         Menu |          - | op = 0                    | op == 0  | Finalitza el programa (surt del bucle)                          |

### CH1 - Train your wizard

| # Instrucció | # Iteració | Variables                                                     | Condició                                           | Resultat esperat                                                                             |
| -----------: | ---------: | ------------------------------------------------------------- | -------------------------------------------------- | -------------------------------------------------------------------------------------------- |
|            1 |          - | wizardName input = "Merlin"                                   | input vàlid                                        | "Merlin" capitalitzat i comença entrenament de 5 dies (5 línies `TrainingSummaryMessage`)    |
|            2 |       1..5 | wizardPoints acumulat (simular RNG fix: 5,7,6,8,9 → total 35) | després del bucle `for (i=1..5)` wizardPoints = 35 | wizardRank ha de ser `Elarion de les Brases` (rang per 35 punts) i mostrar `RankObtainedMsg` |
|            3 |          - | wizardName input = "" (buit)                                  | input invàlid                                      | S’assigna `Gandalf the Grey` i mostra `NameInputErrorMessage`                                |
|            4 |          - | wizardPoints = 10 (simular)                                   | wizardPoints < 20                                  | wizardRank = `Raoden el Elantrí` i mostra `rankMessages[0]`                                  |
|            5 |          - | wizardPoints = 22                                             | 20 ≤ wizardPoints < 30                             | wizardRank = `Zyn el Buguejat` i mostra `rankMessages[1]`                                    |
|            6 |          - | wizardPoints = 31                                             | 30 ≤ wizardPoints < 35                             | wizardRank = `Arka Nullpointer`                                                              |
|            7 |          - | wizardPoints = 42                                             | wizardPoints >= 40                                 | wizardRank = `ITB - Wizard el Gris`                                                          |

### CH2 - Increase LVL

| # Instrucció | # Iteració | Variables                                      | Condició                               | Resultat esperat                                                                                                                                                                      |
| -----------: | ---------: | ---------------------------------------------- | -------------------------------------- | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
|            1 |          - | wizardLevel = 1, rnd dice = 3,2,1... (simular) | monsterHP inicial = 5 (exemple Goblin) | Es mostren `MonsterAppearMsg`, `MonsterStatsMsg` fins que HP ≤ 0, `You rolled` i `DiceFace` per cada tirada; en derrotar-lo mostra `MonsterDefeatMsg`, `LevelUpMsg` i wizardLevel = 2 |
|            2 |          - | wizardLevel = MaxWizardLevel (5)               | en derrotar el monstre                 | Mostra `MonsterDefeatMsg` i `MaxLevelMsg` (no incrementa nivell)                                                                                                                      |
|            3 |          - | monsterHP = 1, diceRoll = 6                    | diceRoll ≥ HP                          | HP ≤ 0 en la primera tirada, mostra `DiceRollMsg`, `DiceDamageMsg` i enemic derrotat                                                                                                  |

### CH3 - Loot the mine

| # Instrucció | # Iteració | Variables                                     | Condició             | Resultat esperat                                                                                                                                 |
| -----------: | ---------: | --------------------------------------------- | -------------------- | ------------------------------------------------------------------------------------------------------------------------------------------------ |
|            1 |          - | digAttempts = 5, map amb moneda a (2,3) només | introduir X=2 Y=3    | Mostra `TryingToDigMsg(2,3)`, `CoinFoundMsg` amb `earnedbits` (si RNG fixat a 10 → suma 10), cel·la en `mineMapDisplay[2,3]` = 🪙, digAttempts-- |
|            2 |          - | intentar coord fora de rang X=5 Y=0           | IndexOutOfRange      | Captura `IndexOutOfRangeException` i mostra `CoordsOutOfRangeMsg`                                                                                |
|            3 |          - | input no numèric                              | falla `int.TryParse` | Mostra `InvalidMapInputMsg` i repeteix sense consumir intent (digAttempts no decrementa)                                                         |
|            4 |          - | casella sense moneda                          | retorna 0            | `mineMapDisplay` marca ❌ i mostra `NothingFoundMsg` i digAttempts--                                                                              |

### CH4 - Show inventory

| # Instrucció | # Iteració | Variables                            | Condició     | Resultat esperat                                         |
| -----------: | ---------: | ------------------------------------ | ------------ | -------------------------------------------------------- |
|            1 |          - | inventoryItems = new string[0]       | longitud 0   | Mostra `InventoryEmptyMsg`                               |
|            2 |          - | inventoryItems = {"Iron Dagger 🗡️"} | longitud > 0 | Mostra `InventoryItemsMsg` i després `- Iron Dagger 🗡️` |

### CH5 - Buy items

| # Instrucció | # Iteració | Variables                                          | Condició             | Resultat esperat                                                                                 |
| -----------: | ---------: | -------------------------------------------------- | -------------------- | ------------------------------------------------------------------------------------------------ |
|            1 |          - | userBits = 50, userShopOption = 2 (Healing Potion) | bits >= preu (10)    | Es resta el preu → userBits = 40, afegeix element a `inventoryItems`, mostra `ShopSuccessBuyMsg` |
|            2 |          - | userBits = 5, opció 1 (Iron Dagger preu 30)        | bits < preu          | Mostra `CardDeclinedMsg`, inventari no canvia                                                    |
|            3 |          - | userShopOption = 0                                 | opció 0              | Mostra `ExitShopMsg`                                                                             |
|            4 |          - | input no numèric                                   | falla `int.TryParse` | Mostra `InvalidShopOptionMsg`                                                                    |
|            5 |          - | opció igual o superior a ShopItems.GetLength(0)    | fora de rang         | Mostra `InvalidShopOptionMsg` (Nota: bug conegut en validació `<` en lloc de `<=`)               |

### CH6 - Show attacks by level

| # Instrucció | # Iteració | Variables       | Condició                         | Resultat esperat                                                                     |
| -----------: | ---------: | --------------- | -------------------------------- | ------------------------------------------------------------------------------------ |
|            1 |          - | wizardLevel = 1 | 1 ≤ level ≤ length(levelAttacks) | Mostra `CurrentLevelMsg` i la llista d'atacs del nivell 1                            |
|            2 |          - | wizardLevel = 3 | 1 ≤ level ≤ length               | Mostra atacs de nivells 1, 2 i 3 (cada header `Level {i} attacks:` i els seus atacs) |
|            3 |          - | wizardLevel = 6 | fora de rang                     | Mostra `NoAttacksAvailableMsg`                                                       |

### CH7 - Decode ancient Scroll

| # Instrucció | # Iteració | Variables                                            | Condició                            | Resultat esperat                                                                                                                                 |
| -----------: | ---------: | ---------------------------------------------------- | ----------------------------------- | ------------------------------------------------------------------------------------------------------------------------------------------------ |
|            1 |          - | ancientScrollSpaces = "The 🐲 sleeps..."             | opció 1                             | S’eliminen espais i mostra `Deciphered Spell: The🐲sleeps...` i `scrollSpacesDecoded = true`                                                     |
|            2 |          - | ancientScrollVowels = "Ancient magic flows..."       | opció 2                             | Compta vocals (majúscules/minúscules): exemple resultat = N → mostra `The number of magical runes (vowels) is: N` i `scrollVowelsDecoded = true` |
|            3 |          - | ancientScrollHiddenNums amb "Ignis 5 ... Aqua 6 ..." | opció 3                             | Extreu "5638" (segons ordre dins el string). `scrollHiddenNumsDecoded = true`                                                                    |
|            4 |          - | executar 1,2,3                                       | després dels tres                   | Mostra missatge de felicitació i `wizardRank = "The String Master Wizard"`                                                                       |
|            5 |          - | input invàlid                                        | falla `int.TryParse` o fora de rang | Mostra `Invalid decode option`                                                                                                                   |

---

Miquel Manzano - [@miquel-manzano](https://github.com/miquel-manzano)

DAMv
