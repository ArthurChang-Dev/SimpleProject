import React from 'react';
import { useState } from 'react';
import { fetchTodoList, fetchTodoTest } from '../api/fetchData.api';

function Header({title}) {
    return (<h1>{title ? title : "Default Title"}</h1>);
}

export default function App() {

    const [result, setResult] = useState(null);

    fetchTodoList(setResult);

    return (
        <div>
            <Header title={"Rocket..🚀 🔥"} />
            <div><h3>{result?.length} items</h3></div>
            <div><button onClick={() => fetchTodoTest()}>Click</button></div>
            <div>
                <table>
                    <thead>
                        <tr>
                            <td>Id</td>
                            <td>Title</td>
                        </tr>
                    </thead>
                    <tbody>
                        {
                            result && result.map(todo => (
                                <tr key={todo.id}>
                                    <td>{todo.id}</td>
                                    <td>{todo.title}</td>
                                </tr>
                            ))
                        }
                    </tbody>
                </table>
            </div>
        </div>
    );
}