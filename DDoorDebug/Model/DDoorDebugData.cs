﻿using System.Collections.Generic;
using UnityEngine;
using static Damageable;
using BepInEx.Configuration;
using System;

namespace DDoorDebug.Model
{
    public class DDoorDebugData
    {
        // Scenes
        public string curActiveScene = string.Empty;
        public string lastActiveScene = string.Empty;
        public string[] allScenes;

        // Player data
        public Damageable dmgObject;
        public WeaponControl wpnObject;
        public WeaponAttackReferences wpnRefs;
        public _ArrowPower magicRefs;
        public PlayerMovementControl movCtrlObject;
        public Rigidbody plrRBody;
        public DamageData lastDamage;
        public SceneCP lastCheckPoint;
        public float lastSave;
        public float lastVelocity;
        public Queue<float> velSamples;
        public Queue<Vector3> posHistSamples;
        public Vector3 lastPosHistSample;
        public float lastVelSampleTime;
        public float lastPosHisSampleTime;
        public string[] bossKeys = new string[] { "bosskill_forestmother", "c_frogdead", "gd_frog_end", "c_grandead", "c_yetidead", "c_oldcrowdead", "c_loddead", "redeemer_complete" };
        public string[] bossesIntroKeys = new string[] { "tut_firstintro", "fomo_intro", "graveyard_westknight", "redeemer_cutscene_watched", "crowboss_intro_watched", "yetiboss_cutscene_watched", "grandma_fight_intro_seen", "grandma_boss_intro_watched", "frog_ghoul_intro", "frog_boss_intro_seen", "frogboss_cutscene_watched", "lod_gauntlet_intro1", "lod_gauntlet_intro2", "lod_gauntlet_intro3", "lod_gauntlet_intro4", "lod_gauntlet_intro5", "lod_gauntlet_intro_done", "lod_demon1", "lod_demon2", "lod_demon3", "lod_demon4", "finallod_intro" };

        // References
        public Dictionary<int, string> dmgTypes;
        public List<DamageableRef> damageables;

    }

    public struct SceneCP
    {
        public int hash;
        public Vector3 pos;
    }

    public struct DamageData
    {
        public float dmg;
        public float poiseDmg;
        public DamageType type;
        public DamageData(float d, float p, DamageType t)
        {
            dmg = d;
            poiseDmg = p;
            type = t;
        }
    }

    public struct Bind
    {
        public KeyCode keycode;
        public String modifiers;
        public bool allowExtraModifiers;
        public ConfigEntry<String> keyEntry;
        public ConfigEntry<String> modEntry;
        public ConfigEntry<String> extraEntry;

        public Bind(ConfigEntry<String> k, ConfigEntry<String> m, ConfigEntry<String> e)
        {
            this.keyEntry = k;
            this.modEntry = m;
            if (k.Value.Length > 0)
            {
                System.Enum.TryParse<KeyCode>(k.Value, out this.keycode);
            }
            else
            {
                this.keycode = KeyCode.None;
            }
            this.modifiers = m.Value;
            this.extraEntry = e;
            this.allowExtraModifiers = e.Value == "t" ? true : false;
        }
    }

}
