using System;
using UnityEngine;
using UnityEngine.Events;

public class InputManagerComponent : MonoBehaviour
{
    //Le fameux InputManager de kyle! permettant l'utilisation de nos touches

    private static byte[] pressedKeys;
    private int nKeys = 4;
    private int nMovementKeysPerPlayer;
    private int nActionKeysPerPlayer;

    [SerializeField]
    private int nPlayers = 1;

    [SerializeField]
    private int nMovementKeys = 4;

    [SerializeField] private int nActionKeys = 1;

    [SerializeField]
    private KeyCode[] keys = new[] { KeyCode.W, KeyCode.A, KeyCode.S, KeyCode.D };

    [SerializeField]
    private UnityEvent<int>[] movementCommands;

    [SerializeField]
    private UnityEvent[] actionCommands;

    private static void PollDigitalInputs(byte[] pressedKeys, KeyCode[] keys, int nKeys)
    {
        for (int i = 0; i < nKeys; ++i)
            pressedKeys[i] = (byte)(Input.GetKey(keys[i]) ? 1 : 0);
    }

    private static void ProcessDigitalInputs(byte[] pressedKeys, UnityEvent<int>[] movementCommands,
        UnityEvent[] actionCommands, int nMovementKeysPerPlayer, int nMovementKeys, int nActionKeysPerPlayer, int currentPlayer)
    {
        //mouvement
        int offset = currentPlayer * nMovementKeysPerPlayer;
        for (int i = 0; i < nMovementKeysPerPlayer; ++i)
            if (pressedKeys[i + offset] == 1)
                movementCommands[i + offset].Invoke(i);

        //actions
        offset = currentPlayer * nActionKeysPerPlayer;


        for (int i = 0; i < nActionKeysPerPlayer; ++i)
            if (pressedKeys[i + nMovementKeys + offset] == 1)
                actionCommands[i + offset].Invoke();

    }

    private void Awake()
    {
        nKeys = keys.Length;
        pressedKeys = new byte[nKeys];
        Debug.Assert(nMovementKeys == movementCommands.Length);
        float nPlayersF = nPlayers;
        nMovementKeysPerPlayer = Mathf.CeilToInt(nMovementKeys / nPlayersF);
        nActionKeysPerPlayer = Mathf.CeilToInt(nActionKeys / nPlayersF);
    }

    private void Update()
    {
        PollDigitalInputs(pressedKeys, keys, nKeys);
        for (int i = 0; i < nPlayers; ++i)
            ProcessDigitalInputs(pressedKeys, movementCommands, actionCommands, nMovementKeysPerPlayer, nMovementKeys,
                nActionKeysPerPlayer, i);
    }
}
