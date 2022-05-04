import React from "react";
import Card from "@material-tailwind/react/Card";
import CardImage from "@material-tailwind/react/CardImage";
import CardBody from "@material-tailwind/react/CardBody";
import CardFooter from "@material-tailwind/react/CardFooter";
import H6 from "@material-tailwind/react/Heading6";
import Paragraph from "@material-tailwind/react/Paragraph";
import Button from "@material-tailwind/react/Button";

const FilmCard = ({movieData}) => {
    return (
        <Card>
            <CardImage
                src="shorturl.at/psBK0"
                alt="Card Image"
            />
            
            <CardBody>
                <H6 color="gray">movie Title</H6>
                <Paragraph>8.7</Paragraph>
                <Paragraph color="gray">
                    description
                </Paragraph>
            </CardBody>

            <CardFooter>
                <Button color="lightGray" size="lg" ripple="light">
                    More...
                </Button>
            </CardFooter>
        </Card>
    );
}


export default FilmCard;