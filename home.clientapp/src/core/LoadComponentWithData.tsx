import React, { useEffect, useState } from "react";
import { get} from "./request";
import { ErrorPage } from "../components/shared/ErrorPage/ErrorPage";
import { Loader } from "../components/shared/Loader/Loader";


export function LoadComponendWithData<TResponse>(
    url: string,
    componentCallback: (data: TResponse) => JSX.Element,
    interval: number = -1) {

    const [data, setData] = useState<TResponse>();
    const [errorData, setErrorData] = useState<Error>();

    useEffect(() => {
        GetAndLoadData(url, setData, setErrorData);

        if (interval > 0)
        {
            const inter = setInterval(() =>
                GetAndLoadData(url, setData, setErrorData), interval);

            return () => {
                clearInterval(inter);
            };
        } 

    }, [url, interval]);

    if (errorData !== undefined)
        return <ErrorPage message={errorData.message}></ErrorPage>

    if (data === undefined) {
        return <Loader></Loader>
    }

    return componentCallback(data);
}

function GetAndLoadData<TResponse>(
    url: string,
    setData: React.Dispatch<React.SetStateAction<TResponse | undefined>>,
    setErrorData: React.Dispatch<React.SetStateAction<Error | undefined>>
) {
    get<TResponse>(url)
        .then(x => setData(x))
        .catch(error => setErrorData(error))
}