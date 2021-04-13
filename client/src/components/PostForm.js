import React, { useContext, useEffect, useState } from "react";
import { PostContext } from "./PostProvider";
import { Button, Form, Col, FormGroup, Label, Input } from 'reactstrap';
import { useHistory, useParams } from 'react-router-dom';

//import React, { useContext, useEffect, useState } from "react"

export const PostForm = () => {
    const { addPost, getAllPosts, } = useContext(PostContext)
    const [isLoading, setIsLoading] = useState(true);
    //const { getUsers } = useContext(UserContext)
    const [post, setPosts] = useState({
        title: "",
        imageUrl: "",
        caption: "",
        userProfileId: 0,
    })
    const handleControlledInputChange = (event) => {
        const newPost = { ...post }
        newPost[event.target.id] = event.target.value
        setPosts(newPost)
    }
    const history = useHistory();


    const handleAddPost = (event) => {

        //POST - add
        addPost({
            title: post.title,
            imageUrl: post.imageUrl,
            caption: post.caption,
            userProfileId: 1,

        })
            .then(setPosts)
    }



    return (
        <>
            <div className="postForm">
                <Form>
                    <FormGroup row>
                        <Label for="newPostTitle" sm={2}>Title:</Label>
                        <Col sm={5}>
                            <Input type="text" name="postTitle" id="title" onChange={handleControlledInputChange} required autoFocus className="form-control" placeholder="Title" />
                        </Col>
                    </FormGroup>
                    <FormGroup>
                        <Label for="imageUrl">Image Url</Label>
                        <Col sm={5}>
                            <Input type="text" name="image" id="imageUrl" onChange={handleControlledInputChange} required autoFocus className="form-control" placeholder="Image Url" />
                        </Col>
                    </FormGroup>
                    <FormGroup>
                        <Label for="caption">Caption</Label>
                        <Col sm={5}>
                            <Input type="text" name="caption" id="caption" onChange={handleControlledInputChange} required autoFocus className="form-control" placeholder="Caption" />
                        </Col>
                    </FormGroup>
                    <FormGroup>
                        <Label for="userProfileId"></Label>
                        <Input type="hidden" name="userProfileId" id="userProfileId" onChange={handleControlledInputChange} required autoFocus className="form-control" placeholder="" value="1" />
                        <Input type="hidden" name="dateCreated" id="dateCreated" onChange={handleControlledInputChange} required autoFocus className="form-control" placeholder="" value="04/12/2021" />
                        <Button
                            className="btn btn-primary"
                            onClick={event => {
                                handleAddPost()
                            }}>Add Post</Button>
                    </FormGroup>
                </Form>
            </div>
        </>
    );
}