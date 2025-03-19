interface IReservedWords {
  get: () => void;
  post: () => void;
  put: () => void;
  patch: () => void;
  delete: () => void;
}

const useReservedWords = (): IReservedWords => {
  const get = () => {
    console.log("get");
  };

  const post = () => {
    console.log("post");
  };

  const put = () => {
    console.log("put");
  };

  const patch = () => {
    console.log("patch");
  };

  const _delete = () => {
    console.log("delete");
  };

  return {
    get,
    post,
    put,
    patch,
    delete: _delete, // or ["delete"]: _delete,
  };
};

class ReservedWords implements IReservedWords {
  get = () => {
    console.log("get");
  };

  post = () => {
    console.log("post");
  };

  put = () => {
    console.log("put");
  };

  patch = () => {
    console.log("patch");
  };

  delete = () => {
    console.log("delete");
  };
}

export function TestReservedWords() {
  let reservedWords = new ReservedWords();
  reservedWords.get();
  reservedWords.post();
  reservedWords.put();
  reservedWords.patch();
  reservedWords.delete();

  reservedWords = {
    get: () => {
      console.log("get");
    },

    post: () => {
      console.log("post");
    },

    put: () => {
      console.log("put");
    },

    patch: () => {
      console.log("patch");
    },

    delete: () => {
      console.log("delete");
    },
  };
  reservedWords.get();
  reservedWords.post();
  reservedWords.put();
  reservedWords.patch();
  reservedWords.delete();

  reservedWords = useReservedWords();
  reservedWords.get();
  reservedWords.post();
  reservedWords.put();
  reservedWords.patch();
  reservedWords.delete();
}
