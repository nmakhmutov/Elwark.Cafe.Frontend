import {NextApiRequest, NextApiResponse} from 'next';
import oidc from 'lib/oidc';
import createLoginUrl from 'lib/utils/login-url';

export default async function session(req: NextApiRequest, res: NextApiResponse): Promise<void> {
    try {
        const result = await oidc.getSession(req);
        if (!result?.accessToken) {
            res.writeHead(302, {
                Location: createLoginUrl(req.url)
            });
            res.end();
            return;
        }

        res.json(result);
    } catch (error) {
        res.status(error.status || 500).end(error.message);
    }
}
