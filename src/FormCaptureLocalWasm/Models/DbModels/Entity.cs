﻿namespace FormCaptureLocalWasm.Models.DbModels;

/// <summary>
/// An abstract class that is a parent class of entity classes.
/// </summary>
public abstract class Entity
{
    /// <summary>
    /// Date of row creation.
    /// </summary>
    public DateTime Added { get; set; }

    /// <summary>
    /// ID of a model.
    /// </summary>
    public int ID { get; set; }

    /// <summary>
    /// Date of last update.
    /// </summary>
    public DateTime Updated { get; set; }

    /// <summary>
    /// Method for setting date information during creation of an entity.
    /// </summary>
    public void SetDateAdded()
    {
        Added = DateTime.Now;
        Updated = Added;
    }
}
