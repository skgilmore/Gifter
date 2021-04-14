import React from "react";
import "./App.css";
import { BrowserRouter as Router } from "react-router-dom";
import { PostProvider } from "./components/PostProvider";
import PostList from "./components/PostList";
import Header from "./components/Header";
import { PostForm } from "./components/PostForm";
import ApplicationViews from "./components/ApplicationViews";
import { UserProfileProvider } from "./components/UserProfileProvider";

function App() {
  return (
    <Router>
      <UserProfileProvider>
        <PostProvider>
          <Header />
          <ApplicationViews />
        </PostProvider>
      </UserProfileProvider>
    </Router>
  );
}

export default App;