interface IUniqueIdContainer {
    readonly UniqueId: string;
}

class UniqueIdContainerItemsCache<T extends IUniqueIdContainer>
{
    private _mapObject = new Object();

    // add new item to the cache
    // throw exception if such id already exists
    AddItem(item: T) {
        if (this._mapObject.hasOwnProperty(item.UniqueId)) {
            throw "item with the same id already exists in cache";
        }

        this._mapObject[item.UniqueId] = item;
    }

    // get item by id. 
    // if no item with such id exists, return null
    GetItem(uniqueId: string): T {
        if (this._mapObject.hasOwnProperty(uniqueId)) {
            return this._mapObject[uniqueId] as T;
        }

        return null;
    }
}

// UniqueObject class implements IUniqueContainer 
// interface
class UniqueObject implements IUniqueIdContainer {
    UniqueId: string;

    constructor(uniqueId: string) {
        this.UniqueId = uniqueId;
    }
}

// define a cache storing UniqueObjects 
let uniqueObjectCache = new UniqueIdContainerItemsCache<UniqueObject>();

// add an item to the cache
uniqueObjectCache.AddItem(new UniqueObject("1"));

// get an item from the cache by id
let objFromCache = uniqueObjectCache.GetItem("1");

