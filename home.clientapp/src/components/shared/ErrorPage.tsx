import './ErrorPage.css'

type ErrorPageProps = {
    message: string;
}

export function ErrorPage({ message }: ErrorPageProps) {
    return (
        <div>{message}</div>
    );
}