import React, { useContext } from "react";
import { Switch, Route, Redirect } from "react-router-dom";
import { UserProfileContext } from "./UserProfileProvider";
import PostList from "./PostList";
import { PostForm } from "./PostForm";
import Login from "./Login";
import Register from "./Register";

export default function ApplicationViews() {
    const { isLoggedIn } = useContext(UserProfileContext);


    return (
        <main>
            <Switch>
                <Route path="/" exact>
                    {isLoggedIn ? <PostList /> : <Redirect to="/login" />}
                </Route>

                <Route path="/add">
                    {isLoggedIn ? <PostForm /> : <Redirect to="/login" />}
                </Route>


                <Route path="/:id">{/* TODO: Post Details Component */}</Route>

                <Route path="/login">
                    <Login />
                </Route>

                <Route path="/register">
                    <Register />
                </Route>
            </Switch>
        </main>
    );
};

