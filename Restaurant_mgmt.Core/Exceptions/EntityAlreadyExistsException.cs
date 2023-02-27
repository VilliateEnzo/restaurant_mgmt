namespace Restaurant_mgmt.Core.Exceptions;

public class EntityAlreadyExistsException : Exception
{
    public EntityAlreadyExistsException() : base("The entity already exists.")
    {
    }

    public EntityAlreadyExistsException(string entity) : base($"The {entity} already exist")
    {
    }

    public EntityAlreadyExistsException(string entity, Exception innerException) : base($"The {entity} already exist", innerException)
    {
    }
}