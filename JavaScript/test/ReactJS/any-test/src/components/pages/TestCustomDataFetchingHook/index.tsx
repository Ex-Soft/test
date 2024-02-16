// https://devtrium.com/posts/async-functions-useeffect
// https://www.robinwieruch.de/react-hooks-fetch-data/

import { useEffect, useState } from "react";
import { useDataApi, useCrud } from "../../../hooks";
import "./index.css";

const TestCustomDataFetchingHook: React.FC = () => {
  const baseUrlProducts = `${process.env.REACT_APP_REST_BASE_URL}/products`;
  const [urlProducts, setUrlProducts] = useState(baseUrlProducts);
  const {
    data: dataProductsByUseDataApi,
    isLoading: isLoadingProductsByUseDataApi,
    isError: isErrorProductsByUseDataApi,
    setUrl: getDataProductsByUseDataApi,
  } = useDataApi(urlProducts);
  const [dataProductsByUseCrud, setDataProductsByUseCrud] = useState();
  const [isLoadingProductsByUseCrud, setIsLoadingProductsByUseCrud] =
    useState();
  const [errorProductsByUseCrud, setErrorProductsByUseCrud] = useState();
  const [getDataProductsByUseCrud] = useCrud({
    baseURL: baseUrlProducts,
    setData: setDataProductsByUseCrud,
    setIsLoading: setIsLoadingProductsByUseCrud,
    setError: setErrorProductsByUseCrud,
  });
  const [searchProductsParamsByUseCrud, setSearchProductsParamsByUseCrud] =
    useState<{ search: string }>();

  useEffect(() => {
    getDataProductsByUseDataApi(urlProducts);
  }, [urlProducts]);

  useEffect(() => {
    getDataProductsByUseCrud(searchProductsParamsByUseCrud);
  }, [searchProductsParamsByUseCrud]);

  const showDataProducts = (data: any) => {
    return Array.isArray(data) && data.length ? (
      <div>
        <table>
          <thead>
            <tr>
              <th>id</th>
              <th>title</th>
              <th>price</th>
              <th>sku</th>
              <th>imageUrl</th>
            </tr>
          </thead>
          <tbody>
            {data.map((item: any, index: number) => (
              <tr key={index}>
                <td>{item.id}</td>
                <td>{item.title}</td>
                <td>{item.price}</td>
                <td>{item.sku}</td>
                <td>{item.imageUrl}</td>
              </tr>
            ))}
          </tbody>
        </table>
      </div>
    ) : (
      <div>There is no data</div>
    );
  };

  return (
    <div>
      <h1>Test Custom Data Fetching Hook</h1>
      <div className="table">
        <input
          type="text"
          onChange={(e) => {
            setUrlProducts(
              `${baseUrlProducts}${
                !!e.target.value ? `?search=${e.target.value}` : ""
              }`
            );
            setSearchProductsParamsByUseCrud(
              !!e.target.value ? { search: e.target.value } : undefined
            );
          }}
        />
        <input
          type="button"
          value="500"
          onClick={() => setUrlProducts(`${baseUrlProducts}/get500`)}
        />
      </div>
      <hr />
      {isErrorProductsByUseDataApi && <div>Something went wrong ...</div>}
      {isLoadingProductsByUseDataApi ? (
        <div>Loading...</div>
      ) : (
        <div>{showDataProducts(dataProductsByUseDataApi)}</div>
      )}
      <hr />
      {errorProductsByUseCrud && <div>Something went wrong ...</div>}
      {isLoadingProductsByUseCrud ? (
        <div>Loading...</div>
      ) : (
        <div>{showDataProducts(dataProductsByUseCrud)}</div>
      )}
    </div>
  );
};

export default TestCustomDataFetchingHook;
