import React from 'react';
import { useState } from 'react';
import { fetchTodoList, createTodo, deleteTodo } from '../api/todo.api';

function Header({title}) {
    return (<h1>{title ? title : "Default Title"}</h1>);
}

export default function App() {

    const [result, setResult] = useState(null);
    const [todo, setTodo] = useState('');
    const [updated, setUpdated] = useState(1);

    fetchTodoList(updated, setResult);

    const handleAddTodo = () => {
        createTodo(todo, updated, setUpdated);
        setTodo('');
    }

    const handleDelete = (id) => {
        deleteTodo(id, updated, setUpdated);
    }

    return (
        <div>
            <Header title={"Rocket..🚀 🔥"} />
            <div>
                <input value={todo} onChange={(e) => setTodo(e.target.value)}></input>
                <button onClick={() => handleAddTodo()}>Add</button>
            </div>
            <div><h3>{result?.length} items</h3></div>
            {/* <div><button onClick={() => fetchTodoTest()}>Click</button></div> */}
            <div>
                <table>
                    <thead>
                        <tr>
                            <td>Id</td>
                            <td>Title</td>
                            <td>Action</td>
                        </tr>
                    </thead>
                    <tbody>
                        {
                            result && result.map(todo => (
                                <tr key={todo.id}>
                                    <td>{todo.id}</td>
                                    <td>{todo.title}</td>
                                    <td><button onClick={() => handleDelete(todo.id)}>Delete</button></td>
                                </tr>
                            ))
                        }
                    </tbody>
                </table>
            </div>
        </div>
    );
}