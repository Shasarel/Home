export function get<TResponse>(
    url: string
): Promise<TResponse> {
    return request(url, { method: 'GET'})
}

export function post<TBody extends BodyInit, TResponse>(
    url: string,
    body: TBody
): Promise<TResponse> {
    return request(url, {method: 'POST', body: body})
}

export function del<TResponse>(
    url: string
): Promise<TResponse> {
    return request(url, { method: 'DELETE'})
}


function request<TResponse>(
    url: string,
    config: RequestInit = {}
): Promise<TResponse> {
    return fetch(url, config)
        .then((response) => {
            if (!response.ok)
                throw new Error(response.status.toString());
            return response.json()
        })
        .then((data) => data as TResponse);
}