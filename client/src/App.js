import React from "react";
import "./App.css";
import { Route } from "react-router-dom"
import { PostProvider } from "./components/PostProvider";
import PostList from "./components/PostList";
import { PostForm } from "./components/PostForm";

function App() {
  return (
    <div className="App">
      <PostProvider>
        <PostList />
        <PostForm />
      </PostProvider>
    </div>
  );
}

export default App;