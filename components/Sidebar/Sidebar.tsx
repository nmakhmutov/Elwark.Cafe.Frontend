import {Avatar, Drawer, Hidden, Paper} from '@material-ui/core';
import Divider from '@material-ui/core/Divider';
import makeStyles from '@material-ui/core/styles/makeStyles';
import Typography from '@material-ui/core/Typography';
import clsx from 'clsx';
import {Link, Navigation} from 'components';
import Links from 'lib/utils/Links';
import {useFetchUser} from 'lib/utils/user';
import React from 'react';
import SideBarLinks from './SideBarLinks';
import ExitToAppIcon from '@material-ui/icons/ExitToApp';

const useStyles = makeStyles((theme) => ({
    root: {
        height: '100%',
        overflowY: 'auto',
    },
    content: {
        display: 'flex',
        flexDirection: 'column',
        minHeight: '100%',
        padding: theme.spacing(2),
    },
    flexGrow: {
        flexGrow: 1
    },
    profile: {
        display: 'flex',
        flexDirection: 'column',
        alignItems: 'center',
        minHeight: 'fit-content',
    },
    avatar: {
        width: 60,
        height: 60,
    },
    name: {
        marginTop: theme.spacing(1),
    },
    divider: {
        marginTop: theme.spacing(2),
    },
    navigation: {
        marginTop: theme.spacing(2),
    },
    logout: {
        marginBottom: 0
    }
}));

export interface SidebarProps {
    onMobileClose: () => void;
    openMobile: boolean;
    className?: string;
}

const Sidebar: React.FC<SidebarProps> = (props) => {
    const {openMobile, onMobileClose, className, ...rest} = props;
    const classes = useStyles();
    const {user} = useFetchUser(true);

    const navbarContent = (
        <div className={classes.content}>
            <div className={classes.profile}>
                <Avatar
                    alt={'Person'}
                    className={classes.avatar}
                    component={Link}
                    src={user?.picture}
                    href={Links.Profile}
                />
                <Typography className={classes.name} variant={'h4'}>
                    {user?.name}
                </Typography>
                <Typography variant={'body2'}>Regular user</Typography>
            </div>
            <Divider className={classes.divider}/>
            <nav className={classes.navigation}>
                {SideBarLinks.map((list) =>
                    <Navigation component={'div'} key={list.title} pages={list.pages} title={list.title}/>
                )}
            </nav>
            <div className={classes.flexGrow}/>
            <Divider className={classes.divider}/>
            <Navigation component={'div'} className={classes.logout} pages={[
                {title: 'Logout', href: Links.Logout, icon: ExitToAppIcon}
            ]}/>
        </div>
    );

    return (
        <>
            <Hidden lgUp>
                <Drawer anchor="left" onClose={onMobileClose} open={openMobile} variant={'temporary'}>
                    <div {...rest} className={clsx(classes.root, className)}>
                        {navbarContent}
                    </div>
                </Drawer>
            </Hidden>
            <Hidden mdDown>
                <Paper
                    {...rest}
                    className={clsx(classes.root, className)}
                    elevation={1}
                    square={true}
                >
                    {navbarContent}
                </Paper>
            </Hidden>
        </>
    );
};

export default Sidebar;
