using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterCreation : MonoBehaviour
{

    GM gm;

    public Button player1openButton;
    public Button player2openButton;

    public GameObject player1Menu;
    public GameObject player2Menu;


    private void Start()
    {
        gm = FindObjectOfType<GM>();
    }

    private void Update()
    {
        if (gm.playerTurn == 1)
        {
            player1openButton.interactable = true;
            player2openButton.interactable = false;
        }
        else
        {
            player2openButton.interactable = true;
            player1openButton.interactable = false;
        }
    }

    public void ToggleMenu(GameObject menu) {
        menu.SetActive(!menu.activeSelf);
    }

    public void CloseCharacterCreationMenus() {
        player1Menu.SetActive(false);
        player2Menu.SetActive(false);
    }

    public void BuyUnit (Unit unit) {

        if (unit.playerNumber == 1 && unit.cost <= gm.player1Gold)
        {
            player1Menu.SetActive(false);
            gm.player1Gold -= unit.cost;
        } else if (unit.playerNumber == 2 && unit.cost <= gm.player2Gold)
        {
            player2Menu.SetActive(false);
            gm.player2Gold -= unit.cost;
        } else {
            print("NOT ENOUGH GOLD, SORRY!");
            return;
        }

        gm.UpdateGoldText();
        gm.createdUnit = unit;

        DeselectUnit();
        SetCreatableTiles();
    }

    public void BuyVillage(Village village) {
        if (village.playerNumber == 1 && village.cost <= gm.player1Gold)
        {
            player1Menu.SetActive(false);
            gm.player1Gold -= village.cost;
        }
        else if (village.playerNumber == 2 && village.cost <= gm.player2Gold)
        {
            player2Menu.SetActive(false);
            gm.player2Gold -= village.cost;
        }
        else
        {
            print("NOT ENOUGH GOLD, SORRY!");
            return;
        }
        gm.UpdateGoldText();
        gm.createdVillage = village;

        DeselectUnit();

        SetCreatableTiles();

    }

    void SetCreatableTiles() {
        gm.ResetTiles();

        Tile[] tiles = FindObjectsOfType<Tile>();
        foreach (Tile tile in tiles)
        {
            if (tile.isClear())
            {
                tile.SetCreatable();
            }
        }
    }

    void DeselectUnit() {
        if (gm.selectedUnit != null)
        {
            gm.selectedUnit.isSelected = false;
            gm.selectedUnit = null;
        }
    }




}
