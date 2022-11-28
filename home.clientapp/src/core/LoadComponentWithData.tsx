import { useEffect, useState } from "react";
import { get} from "./request";
import { ErrorPage } from "../components/shared/ErrorPage/ErrorPage";
import { Loader } from "../components/shared/Loader/Loader";


export function LoadComponendWithData<TResponse>(
    url: string,
    componentCallback: (data: TResponse) => JSX.Element) {

    const [data, setData] = useState<TResponse>();
    const [errorData, setErrorData] = useState<Error>();

    useEffect(() => {
        get<TResponse>(url)
            .then(x => setData(x))
            .catch(error => setErrorData(error))
    }, [url]);

    if (errorData !== undefined)
        return <ErrorPage message={errorData.message}></ErrorPage>

    if (data === undefined) {
        return <Loader></Loader>
    }

    return componentCallback(data);
}