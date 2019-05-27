using Spotify4Unity;
using System.Reflection;
using UnityEditor;
using UnityEngine;

/// <summary>
/// Custom view for the PC Script for Spotify4Unity
/// </summary>
[CustomEditor(typeof(SpotifyService))]
public class SpotifyServiceView : Spotify4UnityBaseView
{
    private SpotifyService m_service = null;

    private void OnEnable()
    {
        m_service = (SpotifyService)target;
    }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        EditorGUILayout.LabelField("PC Spotify Authorization", EditorStyles.boldLabel);

        // Client ID
        GUIContent content = new GUIContent("Client Id", "The Client Id of your application, from Spotify Dashboard");
        m_service.ClientId = EditorGUILayout.TextField(content, m_service.ClientId);
        // Secret ID
        content = new GUIContent("Secret Id", "The Secret Id of your application, from Spotify Dashboard");
        m_service.SecretId = EditorGUILayout.TextField(content, m_service.SecretId);
        // Connection Port
        content = new GUIContent("Connection Port", "The port to use when authenticating. Should be the same as your 'Redirect URI(s)' in your application's Spotify Dashboard");
        m_service.ConnectionPort = EditorGUILayout.IntField(content, m_service.ConnectionPort);

        EditorGUILayout.Space();

        // Auto Connect
        content = new GUIContent("Auto Connect", "Should the service start the authorize process on Start");
        m_service.AutoConnect = EditorGUILayout.Toggle(content, m_service.AutoConnect);

        // Reuse Auth Token
        content = new GUIContent("Reuse Auth Token", "Should the service save the current token to reuse on reopen the application");
        m_service.ReuseAuthTokens = EditorGUILayout.Toggle(content, m_service.ReuseAuthTokens);

        EditorGUILayout.Space();

        // Connection Timeout
        content = new GUIContent("Connection Timeout (s)", "Amount of seconds before failing the authorization process");
        m_service.ConnectionTimeout = EditorGUILayout.IntField(content, m_service.ConnectionTimeout);
        // Update Frequency (ms)
        content = new GUIContent("Update Frequency (ms)", "Should the service prompt the user for reauthorization when the current token has exired - Warning: Will instantly open a browser");
        m_service.UpdateFrequencyMs = EditorGUILayout.IntField(content, m_service.UpdateFrequencyMs);

        EditorGUILayout.Space();

        // Log Level
        content = new GUIContent("Log Level", "Level of logs that should be output to Unity console");
        m_service.LogLevel = (Analysis.LogLevel)EditorGUILayout.EnumPopup(content, m_service.LogLevel);

        EditorGUILayout.Space();

        MarkDirty();
    }
}
