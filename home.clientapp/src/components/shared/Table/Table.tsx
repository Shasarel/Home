import { useState } from "react";
import { del } from "../../../core/request";
import { Icon } from "../../layout/Icon/Icon";
import "./Table.css"

type TableProps = {
    title: string,
    headers: string[],
    rows: string[][],
    deleteUrls: string[]
}

export function Table({ title, headers, rows, deleteUrls }: TableProps) {

    const [rowsState, setRowsState] = useState<string[][]>(rows);

    function deleteRow(url: string, index: number) {
        del(url).then();
        setRowsState(rowsState.filter((_row, i) => index !== i))
    }

    return (
        <div className="tableArea">
            <div className="tableTitle">
                <div>{ title }</div>
                <div className="tableAddButton">
                    <Icon iconName="fa-solid fa-circle-plus"></Icon>
                </div>
            </div>
            <div className="responsiveTable">
                <table className="table">
                    <thead>
                        <tr className="tableEntry">
                            <th scope="col">#</th>
                            {headers.map((item, index) => <th key={index} scope="col">{item}</th>) }
                            <th scope="col">Usuń</th>
                        </tr>
                    </thead>
                    <tbody>
                        {rowsState.map((row, index) =>
                            <tr key={index} className="tableEntry">
                                <th scope="row">{index + 1}</th>
                                {row.map((column, index) => <td key={index}>{column}</td>)}
                                <td className="tableDeleteButton" onClick={() => deleteRow(deleteUrls[index], index)}>
                                <Icon iconName="fa-solid fa-circle-minus"></Icon>
                            </td>
                            </tr>)}
                    </tbody>
                </table>
            </div>
        </div>
    );
}